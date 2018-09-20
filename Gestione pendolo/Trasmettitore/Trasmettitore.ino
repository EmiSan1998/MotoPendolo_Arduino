#include <Arduino.h>

#include "CodaTempi.h"
#include "Id_card.h"
#include "GestioneComandi.h"

const unsigned int FREEZE=50; //Memorizza per quanto tempo dopo una rilevazione il sensore di movimento viene ignorato da Arduino allo scopo di evitare che la stessa oscillazione venga rilevata più volte

CodaTempi CodaTempi; //Archivia temporaneamente i tempi rilevati dal sistema in attesa dell'invio tramite porta seriale

int cnt = 0; //Conta il numero di oscillazioni rilevate da Arduino
unsigned long int interrupt_time = 0; //Memorizza il tempo trascorso dall'accensione di Arduino all'ultima rilevazione
unsigned long int last_interrupt_time=0; //Memorizza il tempo trascorso dall'accensione di Arduino alla penultima rilevazione

void setup()
{
	Serial.begin(9600); //Impostazione del baud rate della porta seriale
	pinMode(2, INPUT_PULLUP); //Impostazione della modalità del pin usato per il collegamento del sensore di movimento
	attachInterrupt(digitalPinToInterrupt(2), tts, RISING); //Quando il pin 2 riceve un segnale il sistema interrompe il loop ed esegue la funzione tts (time to serial)
	pinMode(13, OUTPUT);
	digitalWrite(13, HIGH); //Si imposta il LED 13 come output e lo si accende
}

void loop()
{
 if(Serial.available()){ //Ad ogni interazione del loop il programma controlla se ci sono byte da leggere (un comando è lungo 4 byte)
  GestioneComandi::LeggiEsegui(Serial.read()); //Se ci sono byte da leggere il primo viene letto e passato alla funzione che gestisce i comandi
 }
 while(!CodaTempi.isEmpty()){ //Se la coda dei tempi non è vuota in attesa di nuovi segnali dal sensore i tempi presenti vengono trasmessi al computer
   CodaTempi.pop();
 }
 delay(100); //Tra un iterazione e l'altra c'è una pausa di 0.1 secondi
}

void tts() { //Se viene ricevuto un impulso dal sensore di movimento (ovvero il grave del pendolo è transitato al punto più basso del sistema)
  if(millis()>interrupt_time+FREEZE){ //Se il periodo di "FREEZE" successivo all'ultima rilevazione è trascorso...
		interrupt_time = millis();
		CodaTempi.push(interrupt_time-last_interrupt_time); //...in coda viene inserito un tempo calcolato come la differenza tra l'ultima e la penultima rilevazione...
    last_interrupt_time=interrupt_time; //...il tempo correntemente rilevato come ultima rilevazione diventa la penultima
  }
  else{ //Altrimenti
    interrupt_time=millis(); //Il programma si limita ad aggiornare la variabile che memorizza l'ultima volta che il grave del pendolo è stato rilevato dal sensore di moviento
  }
}
