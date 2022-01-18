// See https://aka.ms/new-console-template for more information
using Week8.Core.BusinessLayer;
using Week8.Core.Models;
using Week8.RepositoryEntityFramework.RepositoryEF;
using Week8.RepositoryMock;

Console.WriteLine("Hello, World!");

//Questa riga fa comunicare i progetti tra loro:IBusiness layer lo collega con core, RepositoryCorsiMock
//Permette di comunicare con il progetto repository 
//IBusinessLayer bl = new BusinessLayer(new RepositoryCorsiMock(), new RepositoryStudentiMock());

IBusinessLayer bl = new BusinessLayer(new RepositoryCorsiEF(), new RepositoryStudentiEF(), new RepositoryDocentiEF());




bool continua = true;

while (continua)
{
    int scelta = SchermoMenu();
    continua = AnalizzaScelta(scelta);
}

int SchermoMenu()
{
    Console.WriteLine("***************Menu**************");
    Console.WriteLine("\nFunzionalità Corsi");
    Console.WriteLine("1.Visualizza Corsi");
    Console.WriteLine("2.Inserire nuovo Corso");
    Console.WriteLine("3.Modificare un Corso");
    Console.WriteLine("4.Eliminare un Corso");
    Console.WriteLine("\nFunzionalità Studenti");
    Console.WriteLine("5.Visualizza elenco completo degli Studenti");
    Console.WriteLine("6.Inserire nuovo Studente");
    Console.WriteLine("7.Modificare email di uno studente");
    Console.WriteLine("8.Eliminare uno Studente");
    Console.WriteLine("9.Visualizza l'elenco degli studenti iscritti ad un corso");
    Console.WriteLine("\nFunzionalità Docenti");
    Console.WriteLine("10.Visualizza elenco completo dei Docenti");
    Console.WriteLine("11.Visualizza l'elenco dei docenti disponibili per una lezione");
    Console.WriteLine("12.Inserire nuovo Docente");
    Console.WriteLine("14.Eliminare un Docente");
    Console.WriteLine("\nFunzionalità Lezioni");
    Console.WriteLine("15.Visualizza elenco completo delle lezioni");
    Console.WriteLine("16.Inserire nuovo Docente");
    Console.WriteLine("17.Eliminare un Docente");
    Console.WriteLine("\n0.Exit");
    Console.WriteLine("**********************************");

    int scelta;
    Console.WriteLine("Inserisci la tua scelta: ");
    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 9))
    {
        Console.WriteLine("Scelta errata. Inserisci una scelta corretta: ");
    }
    return scelta;

}

bool AnalizzaScelta(int scelta)
{
    switch (scelta)
    {
        case 1:
            VisualizzaCorsi();
            break;
        case 2:
            InserisciCorso(codice);
            break;
        case 3:
            ModificaCorso();
            break;
        case 4:
            EliminaCorso();
            break;
        case 5:
            VisualizzaElencoStudenti();
            break;
        case 6:
            AggiungiStudente();
            break;
        case 7:
            ModificareEmailStudente();
            break;
        case 8:
            EliminareStudente();
            break;
        case 9:
            VisualizzaElencoStudentiIscrittiAlCorso();
            break;
        

        case 0:
            return false;
        default:
            break;
    }
    return true;
}

//void VisualizzaElencoDocenti()
//{
//    List<Docente> listaStudenti = bl.GetAllDocenti();

//    //stampa la lista
//    if (listaDocenti.Count == 0)
//    {
//        Console.WriteLine("Lista vuota");
//    }
//    else
//    {
//        foreach (var item in listaDocenti)
//        {

//            Console.WriteLine(item);
//        }
//    }

    void VisualizzaElencoStudentiIscrittiAlCorso()
    {

    }

    void EliminareStudente()
    {
        Console.WriteLine("Ecco l'elenco degli studenti disponibili");
        VisualizzaElencoStudenti();
        Console.WriteLine("Quale studente vuoi eliminare? Inserisci il nome: ");
        string nome = Console.ReadLine();
        Console.WriteLine("Quale studente vuoi eliminare? Inserisci il cognome: ");
        string cognome = Console.ReadLine();
        Console.WriteLine("Quale studente vuoi eliminare? Inserisci l'email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Quale studente vuoi eliminare? Inserisci la data di nascita: ");
        DateTime dataDiNascita = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Quale studente vuoi eliminare? Inserisci il titolo di studio: ");
        string titoloDiStudio = Console.ReadLine();

        Esito esito = bl.RimuoviStudente(nome, cognome, email, dataDiNascita, titoloDiStudio);
        Console.WriteLine(esito.Messaggio);
    }

    void ModificareEmailStudente()
    {

        Console.WriteLine("Inserisci il nome dello studente");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome dello studente");
        string cognome = Console.ReadLine();
        Console.WriteLine("Inseriscila mail dello studente");
        string email = Console.ReadLine();

        Esito esito = bl.ModificaEmailStudente(nome, cognome, email);
        Console.WriteLine(esito.Messaggio);
    }

    void AggiungiStudente()
    {
        //chiedo all'utente i dati per aggiungere un nuovo studente
        Console.WriteLine("Inserisci il nome del nuovo studente");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci il cognome del nuovo studente");
        string cognome = Console.ReadLine();
        Console.WriteLine("Inserisci l'email del nuovo studente");
        string email = Console.ReadLine();
        Console.WriteLine("Inserisci la data di nascita del nuovo studente");
        DateTime dataDiNascita = DateTime.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il titolo di studio del nuovo studente");
        string titolo = Console.ReadLine();

        Studente nuovoStudente = new Studente();

        nuovoStudente.Nome = nome;
        nuovoStudente.Cognome = cognome;
        nuovoStudente.Email = email;
        nuovoStudente.DataDiNascita = dataDiNascita;
        nuovoStudente.TitoloDiStudio = titolo;


        //riga che mi serve per passare all'IbusinessLayer per farlo aggiungere
        //mi serve poi una risposta per sapere se lo ha aggiunto, quindi metto un booleano
        //così---->bool esito=bl.AddNuovoStudente(nuovoStudente);
        //Oppure: devinico nei models una nuova classe dove mi viene restituito sia il booleano che il messaggio
        Esito esito = bl.AddNuovoStudente(nuovoStudente);
        Console.WriteLine(esito.Messaggio);
    }

    void VisualizzaElencoStudenti()
    {
        // List<Studente> listaStudenti = new List<Studente>(); // deve essere popolata con gli studenti// questa è la lista vuota
        //Se voglio popolare la lista faccio così: al posto di new list<Studente> che è vuota, metto l'oggetto bl
        //poi col dot(.) richiamo il metodo GetAll che si trova nella classe che implementa l'interfaccia
        List<Studente> listaStudenti = bl.GetAllStudenti();

        //stampa la lista
        if (listaStudenti.Count == 0)
        {
            Console.WriteLine("Lista vuota");
        }
        else
        {
            foreach (var item in listaStudenti)
            {

                Console.WriteLine(item);
            }
        }
    }




    void EliminaCorso()
    {
        Console.WriteLine("Ecco l'elenco dei corsi disponibili");
        VisualizzaCorsi();
        Console.WriteLine("Quale corso vuoi eliminare? Inserisci il codice: ");
        string codice = Console.ReadLine();

        Esito esito = bl.RimuoviCorso(codice);
        Console.WriteLine(esito.Messaggio);

    }

    void ModificaCorso()
    {
        Console.WriteLine("Ecco l'elenco dei corsi disponibili");
        VisualizzaCorsi();
        Console.WriteLine("Quale corso vuoi modicifcare? Inserisci il codice: ");
        string codice = Console.ReadLine();
        Console.WriteLine("Inserisci il nuovo nome del corso");
        string nuovoNome = Console.ReadLine();
        Console.WriteLine("Inserisci la nuova descrizione del corso");
        string nuovaDescrizione = Console.ReadLine();

        Esito esito = bl.ModificaCorso(codice, nuovoNome, nuovaDescrizione);
        Console.WriteLine(esito.Messaggio);

    }

    void InserisciCorso(int codice)
    {
        //chiedo all'utente i dati per creare il nuovo corso da aggiungere
        Console.WriteLine("Inserisci il codice del nuovo corso");
        int cod = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci il nome del nuovo corso");
        string nome = Console.ReadLine();
        Console.WriteLine("Inserisci la descrizione del nuovo corso");
        string descrizione = Console.ReadLine();

        Corso nuovoCorso = new Corso();
        nuovoCorso.CodiceCorso = codice;
        nuovoCorso.Nome = nome;
        nuovoCorso.Descrizione = descrizione;

        //riga che mi serve per passare all'IbusinessLayer per farlo aggiungere
        //mi serve poi una risposta per sapere se lo ha aggiunto, quindi metto un booleano
        //così---->bool esito=bl.AddNuovoCorso(nuovoCorso);
        //Oppure: devinico nei models una nuova classe dove mi viene restituito sia il booleano che il messaggio
        Esito esito = bl.AddNuovoCorso(nuovoCorso);
        Console.WriteLine(esito.Messaggio);


    }

    void VisualizzaCorsi()
    {
        //recupera la lista dei corsi

        // List<Corso> listaCorsi = new List<Corso>(); // deve essere popolata con i corsi// questa è la lista vuota
        //Se voglio popolare la lista faccio così: al posto di new list<Corso> che è vuota, metto l'oggetto bl
        //poi col dot(.) richiamo il metodo GetAll che si troca nella classe che implementa l'interfaccia
        List<Corso> listaCorsi = bl.GetAllCorsi();

        //stampa la lista
        if (listaCorsi.Count == 0)
        {
            Console.WriteLine("Lista vuota");
        }
        else
        {
            foreach (var item in listaCorsi)
            {
                Console.WriteLine(item);
            }
        }
    }
}




