/*
Gli oggetti Rilevazione sono usati come elementi di CodaTempi
*/

#pragma once

#include<arduino.h>

#include "Serial_util.h"

class Rilevazione
{
public:
	void SetTempo(unsigned int);
	void printTempo();
	void setSuccessivo(Rilevazione*);
	Rilevazione* get_successivo();

private:
	unsigned int tempo;
	Rilevazione* successivo;
};
