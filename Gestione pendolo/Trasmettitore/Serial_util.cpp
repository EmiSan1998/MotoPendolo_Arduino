#include "Serial_util.h"

void Serial_util::int16(int input){ //Questa funzione gestisce la trasmissione di un int16 su seriale
  unsigned char buf[2];
  memcpy(buf,&input,sizeof(int));
  Serial.write(buf,2);
}
