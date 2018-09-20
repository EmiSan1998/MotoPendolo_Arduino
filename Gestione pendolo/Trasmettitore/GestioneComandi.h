/*
La classe GestioneComandi, al momento composta da una sola funzione si occupa di gestire i comandi in arrivo dal computer.
*/

#pragma once

#include<arduino.h>

class GestioneComandi
{
public:
  static bool LeggiEsegui(char comando); //Preso in input un comando da seriale questa funzione lo esegue e restituisce true. Se il comando non è corretto restituisce false
};
