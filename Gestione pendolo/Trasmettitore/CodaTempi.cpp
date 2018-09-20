#include "CodaTempi.h"

CodaTempi::CodaTempi()
{
	testa = NULL;
	coda = NULL;
}

void CodaTempi::push(unsigned int tempo)
{
	Rilevazione* temp = new Rilevazione;
	temp->SetTempo(tempo);
	temp->setSuccessivo(NULL);
	if (testa == NULL) {
		testa = temp;
		coda = temp;
	}
	else {
		coda->setSuccessivo(temp);
		coda = temp;
	}
}

bool CodaTempi::pop()
{
	if (testa == coda) {
		testa->printTempo();
		delete testa;
		testa = NULL;
		coda = NULL;
    return true;
	}
	else {
		testa->printTempo();
		Rilevazione* temp = testa;
		testa = testa->get_successivo();
    delete temp;
    return true;
	}
}

bool CodaTempi::isEmpty(){
  if(testa==NULL){
    return true;
  }
  else{
    return false;
  }
}
