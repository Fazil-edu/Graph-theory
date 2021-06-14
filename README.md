# Graph-Theory


## Tiefensuche

Die Tiefensuche ist ein Algorithmus zum aufspannen eines Spannbaumes von einem Graphen. Wie der Name schon sagt, geht der Algorithmus zum aufspannen in die Tiefe, d. h. er geht solange wie möglich an einem Pfad endlang. Der Algorithmus determiniert, wenn alle Knoten Teil des Spannbaumes sind.

#### Beispiel

![Tiefensuche Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Depth-First%20search.png "Beispiel Tiefensuche")



## Breitensuche

Die zweite Möglichkeit einen Spannbaum zu finden ist die Breitensuche. Auch bei diesem Algorithmus kann man am Namen erkennen, wie dieser vorgeht. Von einem Startknoten werden zunächst alle ausgehenden Kanten abgelaufen. Anschließend werden alle ausgehenden Kanten von den hinzugefügten Knoten abgelaufen und hinzugefügt, wenn kein Kreis entsteht, d. h. dass der Knoten noch nicht Teil des Spannbaumes ist. Der Algorithmus determiniert, wenn alle Knoten Teil des Spannbaumes sind.

#### Beispiel

![Breitensuche Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Breadth-First%20search.png "Beispiel Breitensuche")



## Algorithmus von Boruvka 

Um die folgenden Algorithmen zur Bestimmung des minimalen Spannbaumes besser vergleichen zu können, wird von nun an immer der selbe Beispielgraph genutzt. 
Der Algorithmus von Boruvka ist ein Algorithmus zur Bestimmung des minimalen Spannbaums. Der gegebene Graph muss zusammenhängend und ungerichtet sein damit der Algorithmus anwendbar ist. Wähle den ersten Knoten (z. B. alphabetisch sortiert) und erstelle ein Teilbaum mit dem Knoten mit den geringsten Kosten. In den nächsten Iterationen werden diese beiden Knoten nicht mehr berücksichtigt. Wenn alle Knoten Teil eines Teilbaumes sind, müssen diese mithilfe der günstigsten Verbindungskanten (welche kein Kreis bildet) verbunden werden und man erhält den minimalen Spannbaum.

#### Beispiel

![Boruvka Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Boruvka-Example-Graph.png "Beispiel für den Algorithmus von Boruvka")

Der Knoten A wird zuerst gewählt. Die geringste Kante von Knoten A ist gewichtet mit 4 und führt zu Knoten C. 

![Boruvka Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Boruvka-Example-Graph2.png "Beispiel für den Algorithmus von Boruvka")

In der nächsten Iteration wird der Knoten B betrachtet. Die von dem Knoten B aus günstigste Kante ist mit einem Gewicht von 6 die Kante zum Knoten D. 
Da die Knoten C und D bereits in einem Teilgraph enthalten sind, werden diese bei den nächsten Iterationen nicht berücksichtigt und es wird mit dem Knoten E fortgefahren. Hier führt die minimale Kante zum Knoten F. Da alle Knoten nun Teil von Teilbäumen sind, ist die erste Phase abgeschlossen. 

![Boruvka Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Boruvka-Example-Graph3.png "Beispiel für den Algorithmus von Boruvka")

Hier ist nun die zweite Phase zu beobachten. Die Frage ist: Wie kann man die Teilbäume optimal zu einem Spannbaum verbinden. Die Antwort ist einfach. Nehme die geringsten Kanten, die nicht Teil eines Teilbaumes sind und keinen Kreis schließen. Im obigen Bild ist zu sehen, dass die geringsten Gewichte die Kanten zwischen den Knoten D und F und den Knoten C und F haben. Beide Kanten können ausgewählt werden, da kein Kreis geschlossen wird. Der minimale Spannbaum wurde gefunden. 



## Algorithmus von Kruskal

Wie der Algorithmus von Boruvka, ermittelt der Algorithmus von Kruskal den minimalen Spannbaum eines Graphen. Außerdem müssen auch beim Algorithmus von Kruskal, die Graphen zusammenhängend und ungerichtet sein. Die Art und Weise wie die Algorithmen zum Ziel gelangen, ist jedoch unterschiedlich. Beim Algorithmus von Kruskal werden von Anfang an die Kanten mit der globalen geringsten Gewichtung genommen und markiert, wenn diese keinen Kreis schließen.

#### Beispiel

![Kruskal Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Kruskal-Example-Graph1.png "Beispiel für den Algorithmus von Kruskal")

Die Kante mit der geringsten Gewichtung (4) ist die Kante zwischen den Knoten A und C. Diese kann problemlos in den Spannbaum aufgenommen werden, da sie, aufgrund dass sie die erste Kante ist, kein Kreis schließen kann. 

![Kruskal Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Kruskal-Example-Graph2.png "Beispiel für den Algorithmus von Kruskal")

Die zweite Kante ist die Kante zwischen den Knoten E und F. Sie schließt ebenfalls ein Kreis und kann somit in den Spannbaum aufgenommen werden. Die nächst kleineren Kanten sind mit 6 gewichtet. Da es 2 Kanten mit derselben Gewichtung sind, ist es egal welche zunächst genommen wird. Im Beispiel wurde sich für die Kante zwischen Knoten B und D entschieden es hätte aber auch die Kante zwischen D und F gewählt werden können. Die gewählte Kante schließt ebenfalls kein Kreis und wird aufgenommen. 

![Kruskal Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Kruskal-Example-Graph3.png "Beispiel für den Algorithmus von Kruskal")

Im obigen linken Teil wird dann die vorhin nicht gewählte Kante gewählt und hinzugefügt (Hier: die Kante zwischen den Knoten D und F). Zum Schluss wird noch die Kante zwischen den Knoten C und F hinzugefügt und der minimale Spannbaum wurde gefunden.



## Algorithmus von Prim 

Der letzte Algorithmus zum aufspannen von minimalen Spannbäumen ist der Algorithmus von Prim. Wie auch bei den Vorgängern muss der Graph zusammenhängend und ungerichtet sein. Der Algorithmus beginnt bei einem frei wählbaren Knoten, dieser ist der erste Teilspannbaum. Anschließend werden iterativ die Kanten mit der geringsten Gewichtung, welche von dem Teilspannbaum ausgehen ausgewählt und dem Teilspannbaum hinzugefügt, falls diese kein Kreis schließt.

#### Beispiel

![Prim Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Prim-Example-Graph1.png "Beispiel für den Algorithmus von Prim")

Als Startknoten wurde der Knoten A gewählt. Die geringste ausgehende Kante ist die Kante zu C. Diese wird in den Teilspannbaum aufgenommen.

![Prim Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Prim-Example-Graph2.png "Beispiel für den Algorithmus von Prim")

Anschließend wird die nächste Kante ausgewählt. Es wird diesmal die geringste ausgehende Kante der Knoten A und C gesucht, welche noch nicht im Teilspannbaum enthalten ist und kein Kreis schließt. Deshalb wird die Kante von Knoten C zu Knoten F ausgewählt. Bei der nächsten Iteration wird die Kante zwischen E und F gewählt und eingefügt. 

![Prim Beispiel](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Prim-Example-Graph3.png "Beispiel für den Algorithmus von Prim")

Zuletzt werden noch die beiden Kante mit einer Gewichtung von 6 aufgenommen und der minimale Spannbaum wurde gefunden.


## Algorithmus von Dijkstra

Der Algorithmus von Dijkstra ist ein kürzeste Wege Algorithmus. Er behandelt das Single-Source-Shortest-Path-Problem indem er von einem frei wählbaren Knoten die kürzesten Wege zu allen anderen Knoten des Graphen berechnet. Der Algorithmus geht dabei wie folgt vor: 
1. Lege einen Startknoten fest
2. Wege zu allen anderen Knoten notieren
3. Knoten mit geringsten Abstand zum Startknoten wird ausgewählt 
4. Bestimme alle neuen Wege zu jedem Knoten über den ausgewählten Knoten
    1. 	Sind die neuen Wege kürzer als die bisherigen:
  	    - speichere die Länge und den Vorgänger (der ausgewählte Knoten)
    2.  Sind die neuen Wege länger: 
	      - keine Veränderungen

Wiederhole Schritt 3 bis 5 bis alle Knoten ausgewählt wurden.

#### Beispiel

![Beispiel Graph](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Example-Graph-Shortest-Path.png "Beispiel Graph")

Im Folgenden werden Änderungen in der Tabelle rot markiert. Außerdem sind leere Felder unendliche Verbindungen.

![Beispiel Dijkstra](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Dijkstra-Table1.png "Beispiel für den Algorithmus von Dijkstra")

In der initialen Tabelle sind alle direkten Verbindungen zum Startknoten vermerkt (Startknoten hier: Knoten A). Da die Kante mit der kürzesten Distanz zwischen A und B mit einer Gewichtung von 1 liegt, wird Knoten B ausgewählt. 

![Beispiel Dijkstra](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Dijkstra-Table2.png "Beispiel für den Algorithmus von Dijkstra")

Der Weg von Knoten A über Knoten B zu Knoten D ist kürzer (7) als der direkte Weg von Knoten A zu Knoten D (8). Darum wird die Distanz auf 7 gesetzt und der Vorgänger auf B. Für die nächste Iteration wird der Knoten C gewählt.

![Beispiel Dijkstra](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Dijkstra-Table3.png "Beispiel für den Algorithmus von Dijkstra")

Nun können zum ersten Mal Wege von Knoten A zu den Knoten E und F verzeichnet werden. Als Nächstes wird der Knoten E ausgewählt, da er den kürzesten Weg, der noch nicht bearbeitet wurde, besitzt.

![Beispiel Dijkstra](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Dijkstra-Table4.png "Beispiel für den Algorithmus von Dijkstra")

Auch hier gibt es wieder eine Verbesserung. Gemeint ist damit, dass der Weg zum Knoten F verkürzt werden kann, wenn man über den Knoten E geht. Dadurch verringert sich die Distanz auf 10. Im Folgenden wird auf eine genauere Betrachtung verzichtet, da keine Änderungen mehr vorgenommen werden.

![Beispiel Dijkstra](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Dijkstra-Table5.png "Beispiel für den Algorithmus von Dijkstra")

Es wurden alle kürzesten Wege von Knoten A zu jedem anderen Knoten gefunden. Aber wie genau ist diese Tabelle jetzt zu verstehen?
Die Tabelle wird anhand des Weges von Knoten A zu Knoten F erklärt. Betrachtet man die Zeile F ist zu sehen, dass die Distanz 10 beträgt. Außerdem sieht man den direkten Vorgänger (Knoten E). Anschließend betrachtet man die Zeile des Vorgängers. Hier sieht man, dass dieser auch wieder einen Vorgänger hat (hier: Knoten C). Wenn man nun diesen betrachtet ist zu sehen, dass dieser den Startknoten als Vorgänger hat und somit der Pfad konstruiert werden kann. D. h. Der kürzeste Weg von Knoten A zu Knoten F führt über Knoten C und Knoten E zu Knoten F bei einer Distanz von 10.


## A*-Algorithmus

Der A*-Algorithmus kann als erweiterter Algorithmus von Dijkstra gesehen werden. Er bestimmt auch kürzeste Wege. Allerdings bestimmt dieser nicht alle kürzesten Wege von einem Startknoten zu allen anderen Knoten, sondern von einem frei wählbaren Startknoten zu einem frei wählbaren Endknoten. Außerdem gibt es bei der Entscheidung welcher Knoten als nächstes betrachtet wird einen Unterschied. Der A*-Algorithmus nutzt für diese Entscheidung eine Heuristik. Diese muss jedoch bestimmte Bedingungen erfüllen. 

![Beispiel Graph](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Example-Graph-Shortest-Path.png "Beispiel Graph")

Die Heuristik, die hier angewendet wird, besteht aus der Distanz und der geringsten ausgehenden Kante, welche summiert f ergeben. Im folgenden Beispiel ist der Knoten A als Startknoten und der Knoten F als Endknoten bestimmt worden. 

![Beispiel A*](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/AStar-Table1.png "Beispiel des A*-Algorithmus")

Zu Beginn werden alle Distanzen, der mit dem Startknoten verbundenen Knoten, bestimmt. Wenn auf diesen nun die geringsten ausgehenden Kanten addiert werden erhält man f (Bsp. Knoten C: Von A zu C = 4 und von C zu E = 1 < C zu F = 7, somit ist f = 4 + 1 = 5). Wenn der Algorithmus von Dijkstra angewendet werden würde, würde der Knoten B gewählt werden, da die Distanz lediglich 1 beträgt. Hier wird jedoch Knoten C gewählt, da f am kleinsten ist.

![Beispiel A*](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/AStar-Table2.png "Beispiel des A*-Algorithmus")

Es wird der erste Weg zum Zielknoten gefunden. Jedoch steht noch nicht fest, ob dieser Weg auch der optimale Weg ist. Für die nächste Iteration wird der Knoten B gewählt.

![Beispiel A*](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/AStar-Table3.png "Beispiel des A*-Algorithmus")

Durch Knoten B als Zwischenknoten, wird lediglich der Weg zu Knoten D verkürzt. Das kleinste f, welches noch nicht abgearbeitet wurde, ist 10 und gehört zu dem Knoten E. 

![Beispiel A*](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/AStar-Table4.png "Beispiel des A*-Algorithmus")

Es ist zu erkennen, dass sich die Distanz und somit auch f von Knoten F um 1 verringert. Die Werte von Knoten D bleiben unverändert. Dadurch kommt es nun zur Abbruchbedingung, da f von Knoten F kleiner ist als f von Knoten D. Der kürzeste Weg von Knoten A zu Knoten F wurde also gefunden. Außerdem ist anzumerken, dass wirklich nur die Verbindung von A zu F, sowie die Verbindungen von A zu den Knoten auf dem Weg zu F optimal sind. Zu verstehen ist die Endtabelle wie folgt: Man guckt in die Reihe des Endknotens und betrachtet den Vorgänger. Anschließend betrachtet man die Reihe des Vorgängers und sucht den Vorgänger von diesen. Dies wird so lange fortgeführt bis es keinen Vorgänger mehr gibt (Vorgänger Startknoten = -). Zuletzt ist die Reihenfolge umzudrehen und man erhält den Weg von Startknoten zum Zielknoten. Im Beispiel lautet der Weg somit A -> C -> E -> F.


## Floyd-Warshall Algorithmus

Der Floyd-Warshall Algorithmus löst das All-Pairs-Shortest-Path-Problem (Alle paarweise kürzesten Wege werden gesucht). Zu Beginn wird die Initialmatrix erstellt. Anschließend wird durch alle Knoten durch iteriert. Die Zeile und Spalte des ausgewählten bleibt unberührt. Für alle anderen Einträge der Matrix wird überprüft, ob mithilfe des ausgewählten Knotens ein kürzerer Weg gefunden werden kann. 

![Beispiel Graph](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Example-Graph-Shortest-Path.png "Beispiel Graph")

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table1.png "Beispiel für den Floyd-Warshall Algorithmus")

Es wurde die Initialmatrix erstellt. Im Folgenden wird durch die einzelnen Knoten durch iteriert.

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table2.png "Beispiel für den Floyd-Warshall Algorithmus")

Wenn der Knoten A als Zwischenknoten zur Verfügung steht, entsteht eine Verbindung zwischen den Knoten C und Knoten D und eine Verbindung zwischen den Knoten B und C. Auf die folgenden Iterationen wird nicht genauer eingegangen, da es vom Prinzip genau gleich bleibt.

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table3.png "Beispiel für den Floyd-Warshall Algorithmus")

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table4.png "Beispiel für den Floyd-Warshall Algorithmus")

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table5.png "Beispiel für den Floyd-Warshall Algorithmus")

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table6.png "Beispiel für den Floyd-Warshall Algorithmus")

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table7.png "Beispiel für den Floyd-Warshall Algorithmus")

Es wurde durch den letzten Knoten durch iteriert und es wurden alle kürzesten Wege gefunden. Beispielhaft wird zum Vergleich mit dem A*-Algorithmus der Weg von Knoten A zu Knoten F betrachtet. Um den Weg anhand der Tabelle herauszufinden, können die Ergebnisse rekursiv aufgespalten werden. 

![Beispiel Floyd](https://github.com/JoBo33/Graph-Theory/blob/main/GraphTheory/Examples/Floyd-Table%20result%20explanation.png "Beispiel Floyd-Ergebnistabelle aufgespalten")

Abgelesen aus dem Baum ergibt sich dann der Weg A -> C -> E -> F mit einer Distanz von 10.
