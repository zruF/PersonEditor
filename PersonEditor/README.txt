Anmerkungen:

~~

In PersonRepository.cs bin ich zB noch etwas unzufrieden mit dem Update und dem Löschen. Normalerweise sollte die Addresse mit der Person mitgelöscht werden und beim Update
die Addresse mit der Person gespeichert werden. Es werden aber jeweils einzelne Aufrufe für die Addresse getätigt, die man sich optimalerweise sparen kann.

Ich habe grundlegend mal eine Testklasse angelegt, welche die Get-Route testet. Für weitere Tests fehlt mir leider die Zeit.
Außerdem könnte man PersonControllerTests.BeforeEach() noch in eine weitere Klasse auslagern, von der mehrere Testklassen erben könnten.

Die Routen habe ich mit verschiedenen Werten getestet. Eventuell gibt es Randfälle, die unbehandelte Fehler werfen könnten. Grundlegend sollte aber alles abgefangen werden und 
die Properties werden zum Teil mit Attributen validiert, wie zB Geschlecht oder Postleitzahl.

Die Entität Addresse ist jeweils zur Person zugeordnet über eine Id. Ich habe dies einfachheitshalber als 1:1 Beziehung festgelegt. Die Addresse wird jeweils mit der Person mitgelöscht.
Die Option, dass eine Person mehrere Addressen haben kann wäre natürlich schöner.

~~

Fazit:

Mir ist bewusst, dass dies kein "perfektes" Projekt ist. Man kann an manchen Stellen noch einiges ergänzen und verbessern, aber dafür reicht mir die Zeit leider nicht.
Ich hoffe, dass der Rahmen des Projektes in euren Vorstellungen liegt und ihr euch eine genauere Einschätzung von meinem technischen Wissen einholen könnt.





