using System;
// Overnight Solar Battery Depletion Calculator With a 32 kWh Battery

// variables
double startingBatteryLevel = 0; // Starting battery level in kWh
double householdLoadkWh = 0; // Household load in kWh 
double runTimehrs = 0; // Run time in hours
double totalBatteryCapacity = 0; // Total battery capacity in kWh

//General formula -> Erem = Eo - (P * t)
    // Erem = Remaining energy in the battery after a certain time
    // Eo = Initial energy in the battery
    // P = Power consumption of the household load in kW
    // t = Time in hours

// Formula for Eo -> Eo = Ctot * SoCo
    // Ctot = Total battery capacity in kWh
    // SoCo = Initial State of Charge (starting battery level as you start the night)

//Display introductory message
Console.WriteLine("                      ===== OVERNIGHT SOLAR BATTERY DEPLETION CALCULATOR =====");
Console.WriteLine("This program will help you determine if your battery bank can safely sustain your home until sunrise.");
Console.WriteLine("----------------------------------------------------------------------------------------------------");

//Display Total Battery Capacity
Console.Write("\n|| Please enter the Total Capacity of your Battery (kWh) > ");
while (!double.TryParse(Console.ReadLine(), out totalBatteryCapacity))
{
    Console.WriteLine("Invalid Input please try again!.");
    Console.Write("\n|| Please enter the Total Capacity of your Battery (kWh) > ");
}
Console.WriteLine($"] Your total battery capacity is {totalBatteryCapacity}kWh");



//Phase 1: Get user input for calculating of initial energy (Eo)
Console.Write("\n] Please enter the percentage of your battery, at the time where the house started relying on its stored power. ||");
Console.Write("\n|| Enter initial state of charge of battery (0 to 100) > ");
while (!double.TryParse(Console.ReadLine(), out startingBatteryLevel))
{
    Console.WriteLine("Invalid Input please try again!");
    Console.Write("\n|| Enter initial state of charge of battery (0 to 100) > ");
}
Console.WriteLine($"] Initial state of charge is at {startingBatteryLevel}%");


double startingBatteryPercent = startingBatteryLevel / 100; // Convert percentage to decimal

//Calculate initial energy (Eo)
double initialEnergy = totalBatteryCapacity * startingBatteryPercent; // Eo = Ctot * SoCo

//Display initial energy in the battery
Console.WriteLine($"\n] Initial energy in the battery at {startingBatteryLevel}% is {initialEnergy}kWh");




//Phase 2: Formula Execution

//Asking for household load.
Console.WriteLine("\n] Please enter the average household load (consumption in kW).");
Console.Write("|| Enter average household load (kW) > ");
while (!double.TryParse(Console.ReadLine(), out householdLoadkWh))
{
    Console.WriteLine("Invalid Input please try again");
    Console.Write("|| Enter average household load (kW) > ");
}


//Asking for run time.
Console.WriteLine("\n] Please enter the number of hours the household will be running on battery power.");
Console.Write("|| Enter run time (hours) > ");
while (!double.TryParse(Console.ReadLine(), out runTimehrs))
{
    Console.WriteLine("Invalid Input please try again");
    Console.Write("|| Enter run time (hours) > ");
}


//Calculate remaining energy in the battery after a certain time (Erem)
double remainingEnergy = initialEnergy - (householdLoadkWh * runTimehrs); // Erem = Eo - (P * t)

//Display remaining energy in the battery
Console.WriteLine($"\n] Remaining energy in the battery after {runTimehrs} hours of running on battery power: {remainingEnergy} kWh");

if (remainingEnergy > 0)
{
    Console.WriteLine("] Considering the energy left is less than the initial energy, your battery will be able to sustain your household load until sunrise.");
    Console.WriteLine("\n] The power that your battery has stored is more than enough for the whole night.");
}

if (remainingEnergy < 0)
{
    Console.WriteLine("] The remaining energy in the battery is negative, indicating that your battery will not be able to sustain your household load until sunrise.");
    Console.WriteLine("] Please expect that you will be taking power from the grid to sustain your household load.");
}

if (remainingEnergy == 0)
{
    Console.WriteLine("] The remaining energy in the battery is zero, indicating that your battery will just be able to sustain your household load until sunrise.");
    Console.WriteLine("] Please expect that you will be taking power from the grid to sustain your household load.");
}




