/*
Una normale coda con l'unica differenza che in fase di pop scrive il valore estratto sulla seriale anzichè salvarlo su una variabile
*/

#pragma once

#include <Arduino.h>
#include "Rilevazione.h"  

class CodaTempi
{
public:
	CodaTempi();
	void push(unsigned int);
	bool pop();
  bool isEmpty(); 

private:
	Rilevazione *testa;
	Rilevazione *coda;
};
