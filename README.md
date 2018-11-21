# PAAGridworld2D

Visualizzatore 2D per il progetto GridWorld di Progettazione e Analisi di Algoritmi

* * *

![Immagine di preview](https://raw.githubusercontent.com/smileapplications/PAAGridworld2D/master/Demo.png)

Ho realizzato questo piccolo programma in Unity per poter visualizzare dinamicamente il percorso effettuato dal robottino per il primo Homework di Progettazione e Analisi di Algoritmi (PAA)

Ecco un video che ne mostra il funzionamento semplice su una griglia **150x150**, densità **0.7**, e seed **123456789**

[VIDEO](http://matteocardellini.it/university/GridWorld.mp4)

## Come usarlo

PAAGridworld2D **_NON_** implementa l'algoritmo per il raggiungimento dell'obiettivo bensì **esegue solamente le istruzioni** che gli vengono fornite dal progetto JAVA attraverso un file robot.txt

## Download

Potete trovare il file eseguibile all'interno della sezione releases [releases](https://github.com/smileapplications/PAAGridworld2D/releases) 

### File robot.txt

Il file robot.txt **deve essere inserito nella stessa cartella e allo stesso livello dell'eseguibile**

Il file deve essere formato in questo modo:
1. La prima riga deve contenere **la dimensione della griglia** (es: 4)
2. dalla riga 2 alla riga n+1 deve essere specificata la griglia in questo modo:

```java
File f = new File("/your/path/to/robot.txt");
PrintStream printStream = new PrintStream(f);
printStream.println(gridWidth);

PrintStream stdout = System.out;
System.setOut(printStream);

GridWorld gw = new GridWorld(gridWidth, density, seed);
gw.print();

System.setOut(stdout);
```

Siamo costretti ad utilizzare `System.setOut(printStream)` poichè `gw.print()` al suo interno utilizza un `System.out.println()` che dobbiamo "hackerare" per poter avere su file la griglia

3.  Dobbiamo adesso stampare su file il percorso fatto. Ogni riga corrisponde ad uno step del percorso e deve essere scritto in questo modo -> x,y (Senza parentesi)

#### Esempio di input

Questo è un esempio per una griglia **8x8**, con densita **0.7** e seed **123456789**

    8
    |    @   |
    | @      |
    |@@  @   |
    |@ @ @   |
    |@       |
    |@ @ @   |
    | @@@ @  |
    |@   @ @ |
    0,1
    0,2
    1,2
    2,2
    2,3
    3,3
    4,3
    4,4
    4,5
    5,5
    5,6
    6,6
    6,7
    7,7

Ovviamente il percorso dipende dall'implementazione scelta

### Grafica
In altro a destra trovate tre pulsanti
* Il primo vi permetterà di resettare il robot e di ricaricare il file robot.txt (potete quindi anche cambiare il file al volo senza dover chiudere e riaprire il programma)
* Gli altri due vi permetteranno di aumentare o diminuire la velocità del robot

Inoltre al passaggio del robot le "mattonelle" si coloreranno nel seguente modo:
* ![#FFFF00](https://placehold.it/15/FFFF00/000000?text=+) GIALLO se la mattonella è libera ed è la prima volta che il robot ci passa sopra
* ![#FF0000](https://placehold.it/15/FF0000/000000?text=+) ROSSO se la mattonella non è libera e il robot ci passa sopra lo stesso (=> errore nello scrivere l'input)
* ![#00FFFF](https://placehold.it/15/00FFFF/000000?text=+) AZZURRO se la mattonella è libera ma il robot ci è passato almeno una seconda volta (=> ci sono dei loop nel percorso)
