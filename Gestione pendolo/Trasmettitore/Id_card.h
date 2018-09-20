/*
Id card è una funzione che trasmette la versione del firmware di cronometraggio presente su Arduino in un formato comprensibile dai programmi che vi si interfacciano,
quando questo sistema verrà adattato per l'uso sportivo con realizzazione di un nuovo software per PC che userà i tempi rilevati per creare classifiche e non per analizzare 
il moto di un pendolo questa funzione servirà per prevenire l'uso di firmware obsoleti o errati evitando conflitti derivanti da comandi da parte del PC che Arduino non riesce
a gestire.
*/

#pragma once

#include<arduino.h>

#include "Serial_util.h"  

class Id_card
{
public:
  static void vts(); //Questa funzione trasmette al PC la versione del Firmware installato su Arduino

private:
  static const byte major_release_id = 0; //Questo numero è il progressivo della major release, al momento il firmware è in versione 0.
  static const unsigned int update_id = 4; //Questo numero è il progressivo degli aggiornamenti minori.
  static const char version_id = 'P'; //Questa lettera corrisponde alla tipologia di fimware (P=pendulum, S=sport), ciò permetterà di derivare dallo stesso firmware diverse sottoversioni per usi diversi 

  Id_card() {} //Il costruttore è privato quindi Id_card non può essere istanziata
};
