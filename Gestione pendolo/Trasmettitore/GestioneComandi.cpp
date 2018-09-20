#include "GestioneComandi.h"
#include "Id_card.h"

bool GestioneComandi::LeggiEsegui(char comando)
{
  bool retval=false; //Questa variabile salva il valore che verrà restituito alla fine, di default è false ma se il comando in input è valido la variabile verrà portata a true.
  if(comando=='b'){
    for(int i=0;i<5;i++){
      digitalWrite(13, LOW);
      delay(100);
      digitalWrite(13, HIGH);
      delay(100);
    } 
    retval=true;             
  }
  else if(comando=='p'){
      Serial.write('p');
      retval=true;
    }
  else if(comando=='f'){
    Id_card::vts();
    retval=true;
    }

return retval;
}
