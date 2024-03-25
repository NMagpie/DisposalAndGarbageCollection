using _10._Disposal_and_Garbage_collection;

Console.WriteLine("Subscribing the newsletter. To exit applicaiton type \"q\"");

var topic = "You were subscribed successfully!";

var body = "We thank you for subscribing to out newsletter!";

var consoleInpt = "";

using (var service = new EmailService())
{
    var username = service.Username;

    while (true)
    {
        Console.WriteLine("Enter your email address:");

        consoleInpt = Console.ReadLine();

        if (consoleInpt.Equals("q", StringComparison.CurrentCultureIgnoreCase))
            break;

        try
        {
            service.Client.Send(username, consoleInpt, topic, body);
            Console.WriteLine("The address has been subsribed successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}