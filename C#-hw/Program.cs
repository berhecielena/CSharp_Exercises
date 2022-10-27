// Buna! Acesta este codul de la programul de OTP, realizat in VS Code. Mi-am impartit task-urile pe 3 zile in felul urmator: prima zi + jumatate din a doua zi invatat teorie c# de pe w3 schools iar jumatate din ziua 2 + ziua 3 realizat codul pentru programul de OTP. Programul se ruleaza in consola, unde userul isi va introduce user name-ul si ii va fi generata o parola. Mesajele pe care le poti primi sunt: daca ai introdus parola corect se va afisa "That is correct", daca introduci parola gresit se va afisa "That is not correct" ,iar daca introduci parola indiferent daca e corecta sau gresita si au trecut 30 de secunde se va afisa "Your Password has Expired" si vei fi scos din program. In ceea ce priveste documentatia m-am folosit in mare parte de w3 schools, Stack Overflow, Google si alte pagini de pe Google (sunt foarte multe si nu am pastrat evidenta).

using System;
using System.Collections.Generic;
using System.Timers;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw {
  class Program {
    public static string Password(int length) {
      const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

      StringBuilder stringBuilder = new StringBuilder();
      Random random = new Random();

      for (int i = 0; i < length; i++) {
        int index = random.Next(chars.Length);
        stringBuilder.Append(chars[index]);
      }

      return stringBuilder.ToString();
    }

    static void Main(string[] args) {
      Console.WriteLine("Enter username:");
      var userName = Console.ReadLine();
      Console.WriteLine($"{Environment.NewLine}Hello, {userName}!");

      DateTime dateTime = DateTime.Now;
      Console.WriteLine("We have generated your new password at: {0}", dateTime);

      int length = 4;
      string password = Password(length);

      Console.WriteLine("Generated password:");
      Console.WriteLine(password);
      Console.WriteLine("Type your password");

      Task.Delay(new TimeSpan(0, 0, 30)).ContinueWith(o => {
        PasswordExpired();
      });
      var userInput = Console.ReadLine();

      if (userInput == password) {
        Console.WriteLine("That is correct");
        Environment.Exit(0);
      } else if (userInput != password) {
        Console.WriteLine("That is not correct");
        Environment.Exit(0);
      }

    }

    private static void PasswordExpired() {
      Console.WriteLine("\nYour Password has Expired");
      Environment.Exit(0);
    }

  }
}