using System;
using System.Threading;

namespace RaceConditionExample
{
    internal class CompteBancaire
    {
        private int solde;

        public CompteBancaire(int soldeInitial = 1000)
        {
            this.solde = soldeInitial;
        }

        // Méthode pour retirer de l'argent
        public void Retirer(int montant, int tempsOperation = 50)
        {
            // On récupère le solde dans la variable solde*
            int soldeBis = this.solde;
            // On fait la vérification
            if (soldeBis >= montant)
            {
                // On simule le temps d'attente
                Thread.Sleep(tempsOperation);
                // On fait l'opération sur la variable
                soldeBis -= montant;
            }
            // On change le solde dans le compte par la variable solde*
            this.solde = soldeBis;
        }

        // Méthode pour déposer de l'argent
        public void Deposer(int montant, int tempsOperation = 100)
        {
            // On récupère le solde dans la variable solde*
            int soldeBis = this.solde;
            // On simule le temps d'attente
            Thread.Sleep(tempsOperation);
            // On fait l'opération sur la variable
            soldeBis += montant;
            // On change le solde dans le compte par la variable solde*
            this.solde = soldeBis;
        }

        public decimal GetSolde()
        {
            return this.solde;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // On initialise les variables pour le programme
            int soldeInitial = 1000;
            int sommeRetrait = 1000;
            int sommeDepot = 100;
            int tempsRetrait = 50;
            int tempsDepot = 100;

            // On récupère les arguments de la commande
            if (args.Length > 0) int.TryParse(args[0], out soldeInitial);
            if (args.Length > 1) int.TryParse(args[1], out sommeRetrait);
            if (args.Length > 2) int.TryParse(args[2], out sommeDepot);
            if (args.Length > 3) int.TryParse(args[3], out tempsRetrait);
            if (args.Length > 4) int.TryParse(args[4], out tempsDepot);

            Console.WriteLine(
                $"Solde initial du compte: {soldeInitial} euros\n" +
                $"Somme du retrait: {sommeRetrait} euros\n" +
                $"Somme du dépot: {sommeDepot} euros\n" +
                $"Temps de simulation de l'opération de retrait: {tempsRetrait} ms\n" +
                $"Temps de simulation de l'opération d'ajout: {tempsDepot} ms\n" +
                $"-------------------------------------------------------------------");

            // On instantie un compte avec 1000 euros
            CompteBancaire compte = new CompteBancaire(soldeInitial);

            // On créé un thread pour le retrait...
            Thread retraitThread = new Thread(() =>
            {
                compte.Retirer(sommeRetrait, tempsRetrait);
                Console.WriteLine($"Fin de l'opération de retrait. Solde à la fin de l'opération: {compte.GetSolde()} euros.");
            });

            // ... et pour le dépôt
            Thread depotThread = new Thread(() =>
            {
                compte.Deposer(sommeDepot, tempsDepot);
                Console.WriteLine($"Fin de l'opération de dépot. Solde à la fin de l'opération: {compte.GetSolde()} euros.");
            });

            // On simule une race condition en lançant les deux threads du retrait et du dépôt en même temps
            retraitThread.Start();
            depotThread.Start();

            retraitThread.Join();
            depotThread.Join();

            // On affiche le solde final
            Console.WriteLine($"Solde final: {compte.GetSolde()} euros");
        }
    }
}
