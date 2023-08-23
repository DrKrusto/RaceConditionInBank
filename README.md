# Testing how race conditions could be used maliciously in banking transactions

### How to use the exe in cmd

Entering any values isn't mendatory, if no values are entered default values will be used.

The order of arguments for the exe is:
  - The initial amount of money in the bank account (integer, 1000 by default)
  - The sum of withdraw (integer, 1000 by default)
  - The sum of deposit (integer, 100 by default)
  - The time of wait of the withdraw operation (in milliseconds, 50 by default)
  - The time of wait of the deposit operation (in milliseconds, 100 by default)

For exemple:

```
RaceConditionInBank.exe 1000 1000 100 50 100
```
```
Solde initial du compte: 1000 euros
Somme du retrait: 1000 euros
Somme du dépot: 100 euros
Temps de simulation de l'opération de retrait: 50 ms
Temps de simulation de l'opération d'ajout: 100 ms
-------------------------------------------------------------------
Fin de l'opération de dépot. Solde à la fin de l'opération: 0 euros.
Fin de l'opération de retrait. Solde à la fin de l'opération: 1100 euros.
Solde final: 1100 euros
```
