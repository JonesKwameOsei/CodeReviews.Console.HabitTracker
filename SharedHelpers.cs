using Microsoft.Data.Sqlite;
using Spectre.Console;
using System.Data;
using System.Globalization;

namespace HabitLogger.JonesKwameOsei;

internal class SharedHelpers
{
  internal string GetDate(string message)
  {
    string dateInput;
    do
    {
      dateInput = AnsiConsole.Ask<string>($"[green]{message}[/]");

      if (dateInput == "0") return "0";

      if (DateTime.TryParseExact(dateInput, "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
      {
        return dateInput;
      }

      AnsiConsole.MarkupLine("[red]❌ Invalid date format. Please enter a valid date (dd-MM-yy).[/]");
    } while (true);
  }

  internal string GetValidDate(string prompt, string defaultValue)
  {
    while (true)
    {
      try
      {
        string input = AnsiConsole.Ask(prompt, defaultValue);

        if (DateTime.TryParseExact(input, "dd-MM-yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
          return input;
        }
        else
        {
          AnsiConsole.MarkupLine("[red]Invalid date format. Please use dd-MM-yy format.[/]");
        }
      }
      catch (Exception ex)
      {
        AnsiConsole.MarkupLine($"[red]Input error: {ex.Message}. Please try again.[/]");
      }
    }
  }

  internal bool PromptForWeeklyProgressReport()
  {
    string choice = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("\n📊 Would you like to view the weekly progress report?")
            .AddChoices("Yes", "No")
    );

    return choice == "Yes";
  }

  internal string CreateProgressBar(double percentage, int width = 30, char fillChar = '█', char emptyChar = '░')
  {
    percentage = Math.Clamp(percentage, 0.0, 1.0);
    int filledBars = (int)(percentage * width);
    return "[" + new string(fillChar, filledBars).PadRight(width, emptyChar) + "]";
  }

  internal Panel CreateProgressPanel(string progressBar, string header, Color borderColor, string textColor)
  {
    return new Panel(new Markup($"[{textColor}]{progressBar}[/]"))
        .Header(header)
        .Border(BoxBorder.Rounded)
        .BorderColor(borderColor)
        .Expand();
  }

  internal int GetValidInteger(string prompt, int defaultValue, int minValue, int maxValue, string fieldName)
  {
    while (true)
    {
      try
      {
        int value = AnsiConsole.Ask(prompt, defaultValue);

        if (value >= minValue && value <= maxValue)
        {
          return value;
        }
        else
        {
          AnsiConsole.MarkupLine($"[red]{fieldName} must be between {minValue:N0} and {maxValue:N0}.[/]");
        }
      }
      catch (Exception ex)
      {
        AnsiConsole.MarkupLine($"[red]Input error: {ex.Message}. Please enter a valid number.[/]");
      }
    }
  }

  internal double GetValidDouble(string prompt, double defaultValue, double minValue, double maxValue, string fieldName)
  {
    while (true)
    {
      try
      {
        double value = AnsiConsole.Ask(prompt, defaultValue);

        if (value >= minValue && value <= maxValue)
        {
          return value;
        }
        else
        {
          AnsiConsole.MarkupLine($"[red]{fieldName} must be between {minValue:F1} and {maxValue:F1}.[/]");
        }
      }
      catch (Exception ex)
      {
        AnsiConsole.MarkupLine($"[red]Input error: {ex.Message}. Please enter a valid number.[/]");
      }
    }
  }

  internal void ShowRecordsForSelection(string connectionString, string tableName, string[] columns, string tableTitle, Color borderColor)
  {
    using (SqliteConnection connection = new SqliteConnection(connectionString))
    {
      connection.Open();

      string columnList = string.Join(", ", columns);
      using (SqliteCommand selectCmd = connection.CreateCommand())
      {
        selectCmd.CommandText = $"SELECT {columnList} FROM {tableName} ORDER BY Date DESC LIMIT 10";
        using (SqliteDataReader reader = selectCmd.ExecuteReader())
        {
          if (!reader.HasRows)
          {
            AnsiConsole.MarkupLine("[red]❌ No records found.[/]");
            return;
          }

          Table table = new Table()
              .Border(TableBorder.Simple)
              .BorderColor(borderColor);

          foreach (string column in columns)
          {
            table.AddColumn($"[bold]{column}[/]");
          }

          while (reader.Read())
          {
            string[] rowData = new string[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
              if (reader.IsDBNull(columns[i]))
              {
                rowData[i] = "[dim]No data[/]";
              }
              else
              {
                Object? value = reader[columns[i]];
                rowData[i] = value switch
                {
                  int intVal => intVal.ToString("N0"),
                  double doubleVal => doubleVal.ToString("F2"),
                  string strVal => strVal ?? string.Empty,
                  _ => value?.ToString() ?? string.Empty
                };
              }
            }
            table.AddRow(rowData);
          }

          AnsiConsole.Write(table);
        }
      }
    }
  }

  internal void WaitForKeyPress(string message = "Press any key to continue...")
  {
    AnsiConsole.MarkupLine($"\n[dim]{message}[/]");
    Console.ReadKey();
  }

  internal void ClearConsoleAndWait(string message = "Press any key to continue...")
  {
    WaitForKeyPress(message);
    Console.Clear();
  }
}