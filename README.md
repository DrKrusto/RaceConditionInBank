﻿# Testing how race conditions could be used maliciously in banking transactions

### How to use the exe in cmd

The order of arguments for the exe is:
  - The initial amount of money in the bank account (integer)
  - The sum of withdraw (integer)
  - The sum of deposit (integer)
  - The time of wait of the withdraw operation (in milliseconds)
  - The time of wait of the deposit operation (in milliseconds)

For exemple:

```
RaceConditionInBank.exe 1000 1000 100 100 50
```
```
Solde initial du compte: 1000 euros
Somme du retrait: 1000 euros
Somme du dépot: 100 euros
Temps de simulation de l'opération de retrait: 100 ms
Temps de simulation de l'opération d'ajout: 50 ms
-------------------------------------------------------------------
Fin de l'opération de dépot. Solde à la fin de l'opération: 1100 euros.
Fin de l'opération de retrait. Solde à la fin de l'opération: 0 euros.
Solde final: 0 euros
```
