using System;
using System.Collections.Generic;

namespace LR3
{
	
	public class GameAccount
	{
		private static int _rating = 0;  //рейтинг на який гравці грають 
		private static int _result;
		private static int _index = 1;
		private static readonly List<string> History = new List<string>();
		private static readonly Random Rnd = new Random();

		private static readonly GameAccount Kolia = new GameAccount("KOLIA", 20, "classic");
		static readonly GameAccount Olia = new GameAccount("OLIA", 50,"classic");
		static readonly GameAccount Vania = new GameAccount("VANIA", 10,"classic");
		static readonly GameAccount PlayerX = new GameAccount(" ", 0,"classic");
		static readonly GameAccount Player0 = new GameAccount(" ", 0,"classic");

		
		public string Username { get; set; }
		public int CurrentRating { get; set; }
		public string Account { get; set; }
		
		static readonly char[] Array = new char[9] { '-', '-', '-', '-','-','-','-','-','-'};
		private static string _win;

		public GameAccount(string name, int rating,string account)
		{
			this.Username = name;
			this.CurrentRating = rating;
			this.Account = account;
		}

		public static void SaveHistory(List<string> history,int index, string winner, string loser, int winnerRating, int loserRating)
		{
			history.Add("GAME:" + index+ "\t" + winner +  " VS " + loser + " \t WINNER:" + winner + "[" + winnerRating + "] \t LOSER:" + loser + "[" + loserRating + "]\n");
		}

		public static void GetHistory(List<string> history)
		{
			for (int i = 0; i < history.Count; i++)
			{
				Console.Write(history[i]);
			}
		}
		
		public string PlayerInformation() //інформація про гравця 
		{
			return "Player [name=" + this.Username + ", Rating=" + this.CurrentRating.ToString() + ", Account=" + this.Account+ "]";
		}
		
		public static int WinGame(int ratingPlayer,  int rating) //перемога
		{
			return ratingPlayer + rating;
		}
		
		public static int LoseGame(int ratingPlayer,  int rating) //програш 
		{
			if (Kolia.Account == "vip" || Olia.Account == "vip" || Vania.Account == "vip")
			{
				ratingPlayer -= 0;
			}
			else
			{
				ratingPlayer -= rating;
				if (ratingPlayer < 0)
				{
					ratingPlayer = 0;
				}
			}
			
			return ratingPlayer;
		}
		public static void InformationAboutPlayers() //гра
		{
			//іформація про гравців 
			Console.WriteLine("\n\t\tInformation about players:");
			Console.WriteLine(Kolia.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine(Olia.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------");
			Console.WriteLine(Vania.PlayerInformation());
			Console.WriteLine("----------------------------------------------------------\n");
		}
		
		public static string VipAccount() //преміум аккаунт 
		{
			Console.WriteLine("there is a New Year's promotion. Do you want to give one of the players a VIP account?" +
			                  "If the player has VIP account, he does not lose his rating if he loses");
			Console.WriteLine("1 - yes | 2 - no");
			var yesNo = Console.ReadLine();
			if (yesNo == "1")
			{
				Console.WriteLine("To whom to give VIP?\n 1-Kolia\n 2-Olia\n 3-Vania");
				var playerChoice = Console.ReadLine();
				if (playerChoice == "1")
				{
					return Kolia.Account = "vip";
				}else if (playerChoice == "2")
				{
					return Olia.Account = "vip";
				}else if (playerChoice == "3")
				{
					return Vania.Account = "vip";
				}
			}

			return "status changed";
		}
		
		public static void Game1() //гра
		{
			Console.WriteLine("Would you like to view the player rating?");
			Console.WriteLine("1 - yes | 2 - no");
			var yesNo = Console.ReadLine();
			if (yesNo == "1")
			{
				InformationAboutPlayers();
			}

			VipAccount();
			InformationAboutPlayers();
			Console.WriteLine("Choose the players who will play:");
			Console.WriteLine("1 - kolia + olia\n2 - kolia + vania\n3 - olia + vania");
			var playerChoice = Console.ReadLine();
			if (playerChoice == "1") 
			{
				//гра 1 
				_result =  Rnd. Next(1, 3);
				switch (_result)
				{
					case 1: Kolia.CurrentRating = WinGame(Kolia.CurrentRating, _rating);
						Olia.CurrentRating = LoseGame(Olia.CurrentRating, _rating);
						SaveHistory(History, _index,"kolia", "olia",Kolia.CurrentRating, Olia.CurrentRating);
						break;
				
					case 2 :Olia.CurrentRating = WinGame(Olia.CurrentRating, _rating);
						Kolia.CurrentRating = LoseGame(Kolia.CurrentRating, _rating);
						SaveHistory(History, _index,"olia", "kolia",Olia.CurrentRating, Kolia.CurrentRating);
						break;
				}

				_index++;
				GetHistory(History);
				Choose_classic_game();
				Kolia.Account = "classic";
				Olia.Account = "classic";
				Vania.Account = "classic";
				Game1();
				
			}else if (playerChoice == "2")
			{
				//гра 2 
				_result =  Rnd. Next(1, 3);
				switch (_result)
				{
					case 1: Kolia.CurrentRating = WinGame(Kolia.CurrentRating, _rating);
						Vania.CurrentRating = LoseGame(Vania.CurrentRating, _rating);
						SaveHistory(History, _index,"kolia", "vania",Kolia.CurrentRating, Vania.CurrentRating);
						break;
				
					case 2 :Vania.CurrentRating = WinGame(Vania.CurrentRating, _rating);
						Kolia.CurrentRating = LoseGame(Kolia.CurrentRating, _rating);
						SaveHistory(History, _index,"vania", "kolia",Vania.CurrentRating, Kolia.CurrentRating);
						break;
				}

				_index++;
				GetHistory(History);
				Choose_classic_game();
				Kolia.Account = "classic";
				Olia.Account = "classic";
				Vania.Account = "classic";
				Game1();
				
			}else if (playerChoice == "3")
			{
				//гра 3 
				_result =  Rnd. Next(1, 3);
				switch (_result)
				{
					case 1: Vania.CurrentRating = WinGame(Vania.CurrentRating, _rating);
						Olia.CurrentRating = LoseGame(Olia.CurrentRating, _rating);
						SaveHistory(History, _index,"vania", "olia",Vania.CurrentRating, Olia.CurrentRating);
						break;
				
					case 2 :Olia.CurrentRating = WinGame(Olia.CurrentRating, _rating);
						Vania.CurrentRating = LoseGame(Vania.CurrentRating, _rating);
						SaveHistory(History, _index,"olia", "vania",Olia.CurrentRating, Vania.CurrentRating);
						break;
				}
				_index++;
				GetHistory(History);
				Choose_classic_game();
				Kolia.Account = "classic";
				Olia.Account = "classic";
				Vania.Account = "classic";
				Game1();
				
			}
			
		}

		private static void Choose_classic_game() //вибір гри
		{
			Console.WriteLine("Choose a game:");
			Console.WriteLine("1 - classic game with a rating of 10\n2 - double rated game\n3 - unrated game");
			var typeOfGame = Console.ReadLine();
			if (typeOfGame == "1")
			{
				
				Console.WriteLine("You have chosen a classic game with a rating of 10");
				_rating = 10;
			}
			else if (typeOfGame == "2")
			{
				Console.WriteLine("You have selected a double rated game");
				_rating = 20;
			}
			else if (typeOfGame == "3")
			{
				Console.WriteLine("You have selected a training game without rating");
				_rating = 0;
			}
			
		}
		private static void Board1() //поле гри, нумерація клітинок
	    {
	      Console.WriteLine("Game field: (each cell has a number)");
	      Console.WriteLine("\t-7-|-8-|-9-");
	      Console.WriteLine("\t-4-|-5-|-6-");
	      Console.WriteLine("\t-1-|-2-|-3-");
	    }

	    private static void Board() //поле гри
	    {
	      Console.WriteLine("\t-"+Array[6]+"-|-"+Array[7]+"-|-"+Array[8]+"-" + "\t-7-|-8-|-9-");
	      Console.WriteLine("\t-"+Array[3]+"-|-"+Array[4]+"-|-"+Array[5]+"-" + "\t-4-|-5-|-6-");
	      Console.WriteLine("\t-"+Array[0]+"-|-"+Array[1]+"-|-"+Array[2]+"-" + "\t-1-|-2-|-3-");
	    }

	    private static string Get_Move() //хід гравця
	    {
	      var move = Console.ReadLine();
	      return move;
	    }
	    
	    private static void Victory_check()  //перевірка на виграш
	    {
	      if (Array[0] == 'X' && Array[1] == 'X' && Array[2] == 'X' ||
	          Array[3] == 'X' && Array[4] == 'X' && Array[5] == 'X' ||
	          Array[6] == 'X' && Array[7] == 'X' && Array[8] == 'X' ||
	          Array[0] == 'X' && Array[4] == 'X' && Array[8] == 'X' ||
	          Array[6] == 'X' && Array[4] == 'X' && Array[3] == 'X' ||
	          Array[0] == 'X' && Array[3] == 'X' && Array[6] == 'X' ||
	          Array[1] == 'X' && Array[4] == 'X' && Array[7] == 'X' ||
	          Array[2] == 'X' && Array[5] == 'X' && Array[8] == 'X' 
	         )
	      {
		      _win = PlayerX.Username + " won";
	        Board();
	        Console.WriteLine(_win);
	        Game_over();
	        

	      } else if (Array[0] == '0' && Array[1] == '0' && Array[2] == '0' ||
	                 Array[3] == '0' && Array[4] == '0' && Array[5] == '0' ||
	                 Array[6] == '0' && Array[7] == '0' && Array[8] == '0' ||
	                 Array[0] == '0' && Array[4] == '0' && Array[8] == '0' ||
	                 Array[6] == '0' && Array[4] == '0' && Array[3] == '0' ||
	                 Array[0] == '0' && Array[3] == '0' && Array[6] == '0' ||
	                 Array[1] == '0' && Array[4] == '0' && Array[7] == '0' ||
	                 Array[2] == '0' && Array[5] == '0' && Array[8] == '0' 
	                )
	      { 
		      _win = Player0.Username + " won";
	        Board();
	        Console.WriteLine(_win);
	        Game_over();
	        
	      }
	    }
	    
	    private static void Game_over() //кінець гри
	    {
	        Console.WriteLine("game over | GG WP");
	        System.Environment.Exit(0);
	    }
	    
	    private static void Friendship_won() //перевірка не нічию
	    {
	      if (_win != "X - won" && _win != "0 - won")
	      {
	        Console.WriteLine("Friendship won");
	        Game_over();
	      }
	    }
	    private static void TicTacToe() //Хрестики-нулики
	    {
		    Board1(); //поле гри
     
		    Console.Write("Enter player X's name:");
		    var nameX = Console.ReadLine();
		    PlayerX.Username = nameX;
		    Console.Write("Enter player 0's name:");
		    var name0 = Console.ReadLine();
		    Player0.Username = name0;
		    Console.Write("Enter numbers from 1-9:\n");
		    Console.Write(PlayerX.Username + " your turn, You 'X'\n" );
		    for (int i = 0; i <= 9 ; i++)
		    {
			    Board(); //поле гри
			    int move = Convert.ToInt32(Get_Move());
       
        
        
			    if (i%2 == 0) {
				    Console.Write(Player0.Username + " your turn\n" );
				    Array[move - 1] = 'X';
				    Victory_check();
          
          
			    }else 
			    {
				    Console.Write(PlayerX.Username + " your turn\n" );
				    Array[move - 1] = '0';
				    Victory_check();
          
			    }
		    }
		    Friendship_won();
	    }
		
		 
		public static void Main(String[] args)
		{
			Console.WriteLine("Choose a game:");
			Console.WriteLine("1 - classic game with created players that you control \n2 - Tic-tac-toe");
			var typeOfGame = Console.ReadLine();
			if (typeOfGame == "1")
			{ 
				Choose_classic_game();
				Game1();
			}else if(typeOfGame == "2")
			{
				TicTacToe();
			}
			
		}
	}	
	
}