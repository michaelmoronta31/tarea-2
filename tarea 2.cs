
using System.Collections.Generic;

Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   6. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {
                //Console.WriteLine("Digite el nombre de la persona");
                //string name = Console.ReadLine();
                //Console.WriteLine("Digite el apellido de la persona");
                //string lastname = Console.ReadLine();
                //Console.WriteLine("Digite la dirección");
                //string address = Console.ReadLine();
                //Console.WriteLine("Digite el telefono de la persona");
                //string phone = Console.ReadLine();
                //Console.WriteLine("Digite el email de la persona");
                //string email = Console.ReadLine();
                //Console.WriteLine("Digite la edad de la persona en números");
                //int age = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                ////var temp = Convert.ToInt32(Console.ReadLine());
                ////bool isBestFriend;
                ////if (temp == 1)
                ////{ isBestFriend = true; }
                ////else
                ////{ isBestFriend = false; }
                //bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                //var id = ids.Count + 1;
                //ids.Add(id);
                //names.Add(id, name);
                //lastnames.Add(id, lastname);
                //addresses.Add(id, address);
                //telephones.Add(id, phone);
                //emails.Add(id, email);
                //ages.Add(id, age);
                //bestFriends.Add(id, isBestFriend);

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                foreach (var id in ids)
                {
                    var isBestFriend = bestFriends[id];

                    //string isBestFriendStr;

                    //if (isBestFriend == true)
                    //{
                    //    isBestFriendStr = "Si";
                    //}
                    //else {
                    //    isBestFriendStr = "No";
                    //}

                    string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                    Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                }

            }
            break;
        case 3: //search
            {
                buscar_contacto(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 4: //modify
            {
                modificar_contacto(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 5: //delete
            {
                eliminar_contacto(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
            }
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}
///Buscar contacto
static void buscar_contacto(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Ingrese el nombre o apellido a buscar:");
    string searchTerm = Console.ReadLine().ToLower();
    var foundIds = ids.Where(id => names[id].ToLower().Contains(searchTerm) || lastnames[id].ToLower().Contains(searchTerm)).ToList();
    if (foundIds.Count == 0)
    {
        Console.WriteLine("No se encontraron contactos con ese nombre o apellido.");
        return;
    }
    Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
    Console.WriteLine($"____________________________________________________________________________________________________________________________");
    foreach (var id in foundIds)
    {
        string isBestFriendStr = bestFriends[id] ? "Si" : "No";
        Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
    }
}
//Modificar contacto
static void modificar_contacto(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Ingrese el número de teléfono del contacto a modificar:");
    string phoneToModify = Console.ReadLine();
    int idToModify = telephones.FirstOrDefault(x => x.Value == phoneToModify).Key;
    if (idToModify == 0) 
    {
        Console.WriteLine("No se encontró un contacto con ese número de teléfono.");
        return;
    }
    Console.WriteLine("Deje en blanco si no desea cambiar el dato.");
    Console.WriteLine($"Nombre actual: {names[idToModify]}. Nuevo nombre:");
    string newName = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newName)) names[idToModify] = newName;
    Console.WriteLine($"Apellido actual: {lastnames[idToModify]}. Nuevo apellido:");
    string newLastname = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newLastname)) lastnames[idToModify] = newLastname;
    Console.WriteLine($"Dirección actual: {addresses[idToModify]}. Nueva dirección:");
    string newAddress = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newAddress)) addresses[idToModify] = newAddress;

    Console.WriteLine($"Teléfono actual: {telephones[idToModify]}. Nuevo teléfono:");
    string newPhone = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newPhone))
    {
        telephones[idToModify] = newPhone;
    }
    Console.WriteLine($"Email actual: {emails[idToModify]}. Nuevo email:");
    string newEmail = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(newEmail)) emails[idToModify] = newEmail;
    Console.WriteLine($"Edad actual: {ages[idToModify]}. Nueva edad:");
    string newAge = Console.ReadLine();
    if (int.TryParse(newAge, out int age)) ages[idToModify] = age;
    Console.WriteLine("Es mejor amigo? 1. Si, 2. No");
    string bestFriendInput = Console.ReadLine();
    if (bestFriendInput == "1" || bestFriendInput == "2") bestFriends[idToModify] = bestFriendInput == "1";
    Console.WriteLine("Contacto modificado exitosamente.");
}
//Eliminar contacto
static void eliminar_contacto(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.Write("Ingrese el número de teléfono del contacto a eliminar: ");
    string phoneToDelete = Console.ReadLine();
    int idToDelete = telephones.FirstOrDefault(x => x.Value == phoneToDelete).Key;

    if (idToDelete == 0)
    {
        Console.WriteLine("❌ No se encontró un contacto con ese número.");
        return;
    }
    ids.Remove(idToDelete);
    names.Remove(idToDelete);
    lastnames.Remove(idToDelete);
    addresses.Remove(idToDelete);
    telephones.Remove(idToDelete);
    emails.Remove(idToDelete);
    ages.Remove(idToDelete);
    bestFriends.Remove(idToDelete);
    Console.WriteLine("Contacto eliminado exitosamente.");
}