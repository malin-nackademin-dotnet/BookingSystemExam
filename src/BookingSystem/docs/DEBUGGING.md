# Felsökningsrapport

## Vilket fel undersökte du?
Jag undersökte Fel 3 – Sökningen är skiftlägeskänslig.

## Hur återskapade du felet?
Jag testade att söka flera gånger på både hela namnet och delar av det 
med små och stora bokstäver.

## Vilket resultat fick du?
Applikationen kunde söka på hela eller delar av namn men den var känslig för stora och små
bokstäver. Om det man sökte på hade en annan kombination av stora eller små bokstäver så kunde
den inte hitta bokningen.

## Vilket resultat skulle du ha fått?
Det skulle ha gått att söka på till exempel 'mal' och den skulle ändå ha hittat 'Malin'. Den borde inte
bry sig om stora eller små bokstäver.

## Vilken del av koden orsakade felet?
Contains i denna metod orsakade felet:

```bash
public IReadOnlyList<Booking> Search(string searchTerm)
    {
        return [.. repository.GetAll()
            .Where(booking =>
                !booking.IsCancelled &&
                booking.CustomerName.Contains(searchTerm)];
    }
```

## Varför gav koden ett felaktigt resultat?
Den gav ett felaktigt resultat för Contains kollar om booking innehåller den exakta 
bokstavskombinationen som finns i searchTerm. I denna kod så måste små och stora bokstäver 
stämma överens med namnet i json-filen för att den ska kunna hitta.

## Vad ändrade du?
Jag lade till StringComparison.OrdinalIgnoreCase, villket gör att sökningen inte bryr sig 
om searchTerm innehåller stora eller små bokstäver.

```bash
 booking.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase);
```

Man hade också kunnat sätta ToLower() på både customerName och searchTerm för att kunna jämföra
med bara småbokstäver, då hade sökningen fungerat även om bokstavskombinationen inte stämmer med 
den som finns sparad.

Jag valde StringComparison.OrdinalIgnoreCase eftersom den igonerar skillnaden på stora och små 
bokstäver utan att man behöver omvandla båda strängarna till små bokstäver.

## Hur kontrollerade du att ändringen fungerade?
Jag testade applikationen manuellt genom att söka med både små och stora bokstäver och 
kontrollerade att gick fick tillbaka en matchande bokning även om det sparade namnet hade en 
annan kombination av stora eller små bokstäver. Jag körde även det befintliga testet 
Search_WhenSearchTermHasDifferentCasing_ReturnsBooking() och kontrollerade att det blev grönt.

## Vilket automatiserat test skyddar mot att felet återkommer?
Detta test: Search_WhenSearchTermHasDifferentCasing_ReturnsBooking()

Testet kontrollerar att en sökning med små bokstäver ger tillbaka en bokning med samma namn 
även om det sparade namnet har stora bokstäver i sig.