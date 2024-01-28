# Command Pattern Army
### 🎖 *A game of chance & design* 🎖

Command Pattern Army is a C# CLI game implementing the [Command](https://en.wikipedia.org/wiki/Command_pattern) OOP design pattern to process requests.

### Design Pattern Terms: Game Components
- **Invoker:** the army's commander -- *you & the enemy bot* 
- **Receiver:** the army
- **Command:** the commander's order -- *the actions you or the bot chooses* 

## Getting Starting
- Install [NET 8](https://dotnet.microsoft.com/en-us/download/dotnet)
- Build and run the application: `dotnet build && dotnet run`

## How to Play
🏰 **Goal:** Capture the enemy fort before they annihilate your army.

### Rules

*You have two actions:* ⚔️ **_Attack_** or  🥾 **_Move Forward_**

😈 After each action, the enemy will attack.
  
❌ Every action, including enemy attacks, has a chance for failure 
  
🎲 Attack effectiveness is determined by chance

#### Winners and Losers
🏆 If you reach the enemy base with your army intact, **_you win!!_**
  
☠️ If the enemy annihilates your army before reaching the base, **you lose.**