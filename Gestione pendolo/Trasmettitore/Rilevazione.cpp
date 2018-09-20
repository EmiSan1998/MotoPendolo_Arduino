#include "Rilevazione.h"

void Rilevazione::SetTempo(unsigned int tempo)
{
	this->tempo = tempo;
}

void Rilevazione::printTempo()
{
	Serial_util::int16(this->tempo);
}

void Rilevazione::setSuccessivo(Rilevazione *successivo)
{
	this->successivo = successivo;
}

Rilevazione * Rilevazione::get_successivo()
{
	return this->successivo;
}
