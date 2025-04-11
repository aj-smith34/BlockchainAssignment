using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BlockchainAssignment
{
    class Blockchain
    {
        //creating a list for storing Blocks that are in the Blockchain 
        public static List<Block> Blocks = new List<Block>();       

        //creating a list for transactions that are pending to be processed into the Blockchain
        public static List<Transaction> pendingTransactions = new List<Transaction>();

        //
        public static int transactionSelectionType = 0;





        //CONSTRUCTOR instantiates the genesis block
        public Blockchain()
        { Blocks.Add(new Block()); }      //instantiates a new genesis Block into the Blockchain
     








        //METHOD to return a Block's information in a readable and printable format from the Blockchain with a given index input -
        public static String PrintBlock(int index)

        {
            if (index > Blocks.Count - 1)   
            {                                           //Checks to see if the given index input for a block exists in 
                return ("NULL");                        //the Blockchain, if not, returns 'NULL', otherwise returns 
            }                                           //the Block in a readable printed format -
            else
            {
                return Blocks[index].ReturnBlock();     // < ReturnBlock() formats the selected block information into
            }                                           //a readable format

        }





        //METHOD adds the given transaction to the pending transactions list
        public static void PendTransaction(Transaction transaction)
        {
            pendingTransactions.Add(transaction);   //appends the given transaction to the pending transactions list
        }





        //METHOD returns the balance of a given publicID's wallet by checking each block for transactions involving said publicID.
        //The bool variable, if true, returns a formatted printed version for balance display purposes; if false returns just the
        //number value. Note it is returned as a string, so must be converted to a float/double if to be used for calculations.
        public static string getBalance(string publicID, bool print)
        {
            float walletBalance = 0;    //a wallet always starts at balance 0.
            string transactions = "";

            for (int i = 1; i < Blocks.Count; i++)      //i counter iterates through each block (excluding genesis, hence int i = 1, not 0)
            {
                for (int j = 0; j < Blocks[i].TransactionList.Count; j++)   //j counter iterates through each transaction per block.
                {
                    if (Blocks[i].TransactionList[j].sender == publicID)    //if a transaction includes the publicID as the sender:
                    {
                        walletBalance -= Blocks[i].TransactionList[j].amount + Blocks[i].TransactionList[j].fee;        //deducts the sent amount and fee cost from the walletBalance variable.    
                        transactions += ("\n\n\n< SENT >\n\n" + Blocks[i].TransactionList[j].PrintTransaction());       //adds the sent transaction data to the display balance string.
                    }
                    if (Blocks[i].TransactionList[j].receiver == publicID)              //if a transaction includes the publicID as the receiver:
                    {
                        walletBalance += Blocks[i].TransactionList[j].amount;               //adds the received amount to the walletBalance variable.
                        transactions += ("\n\n\n< RECEIVED >\n\n" + Blocks[i].TransactionList[j].PrintTransaction());   //adds the received transaction data to the display balance string.
                    }
                }
            }
            if(print == true)   //if the print argument is true, returns a print of the wallet balance and transaction info:
            {
                return ("Public ID: " + publicID + "\nBalance: " + walletBalance + "\n\n" + transactions);  //concatenates the publicID, walletBalance, and the list of sent/received transactions in order into one returned string.
            } else {
                return walletBalance.ToString();    //if the print argument is false, returns just the walletBalance value. As the method return type is String, it must be a string so 
                                                    //if to be used for calculations must be converted to a float/double after the value is returned.
            }
        }





        //METHOD recalculates a given blocks' merkle root of all the transaction hashes, and returns whether or not the recalculated merkle
        //root is the same as the block's stored merkle root (so no tampering has occurred), returning as an appropriate boolean value.
        public static bool ValidateMerkleRoot(Block block)
        {
            List<String> TransactionHashes = new List<String>();

            for(int i = 0; i < block.TransactionList.Count(); i++)
            {
                TransactionHashes.Add(block.TransactionList[i].hash);   //iterates through the transactions of the given block, creating a list of just the transaction hashes.
            }
            String reMerkle = block.MerkleRoot(TransactionHashes);      //finds the merkle root of the block's transaction hashes.


            if(reMerkle == block.merkleRoot)    //if the block's stored merkle root is the same as the recalculated merkle root, then the merkle root is valid:
            {                                   //
                return true;                    // <-- if merkle root is the same and thus valid, returns true.
            } else {                            //
                return false;                   // <-- if the merkle root is not the same and thus invalid, returns false.
            }
        }





        //METHOD recalculates the given blocks' hash value, comparing it to the block's stored hash value, and returning an appropriate
        //boolean value if it is the same hash value, or not. If it is not the same, then the block data has been tampered with.
        public static bool ValidateHash(Block block)
        {
            String reHash = block.CreateHash(block.nonce);     //recalculates the block hash (nonce is already found and stored, so no mining)

            if(reHash == block.hash)        //checks that the recalculated hash is the same as the stored hash:
            {                               //
                return true;                // <-- if the hash value is the same and thus valid, returns true.
            } else {                        //
                return false;               // <-- if the hash value is not the same and thus invalid, returns false.
            }
        }





        //METHOD
        public static List<Transaction> SelectTransactions(int n, [Optional] string address)
        {
            List<Transaction> selectedTransactions = new List<Transaction>();

            //n is the value that determines the maximum amount of transactions per block -
            if (pendingTransactions.Count() < n)
            {
                n = pendingTransactions.Count();         //if there is less pending transactions than the maximum amount, sets variable n to how many pending transactions exist.
            }



            if (transactionSelectionType == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    selectedTransactions.Add(pendingTransactions[i]);        //adds the first n transactions from pending transactions to the selected transactions list.
                }

                pendingTransactions = pendingTransactions.Except(selectedTransactions).ToList();  //removes the selected transactions from the pending transactions list.
            }
            else if (transactionSelectionType == 1)
            {
                Random rand = new Random();
                
                for (int i = 0; i < n; i++)
                {
                    int randIndex = rand.Next(pendingTransactions.Count());
                    selectedTransactions.Add(pendingTransactions[randIndex]);  //selects a random transaction in the pending transaction list
                    pendingTransactions.RemoveAt(randIndex);
                }
            }
            else if (transactionSelectionType == 2)
            {
                int max = 0;

                for (int i = 0; i < n; i++)
                {
                    for(int j = 0; j < pendingTransactions.Count()-1; j++)
                    {
                        if(pendingTransactions[max].fee < pendingTransactions[j].fee)
                        {
                            max = j;                            //if the current iterated transaction's fee is larger than the previously found largest transaction fee, this becomes the selected transaction.
                        }
                    }
                    selectedTransactions.Add(pendingTransactions[max]);
                    pendingTransactions.RemoveAt(max);
                }
            }
            else if (transactionSelectionType == 3)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < pendingTransactions.Count()-1; j++)
                    {
                        if(pendingTransactions[j].receiver == address)
                        {
                            selectedTransactions.Add(pendingTransactions[j]);
                            pendingTransactions.RemoveAt(j);
                        }
                    }
                }
            }

            return selectedTransactions;
        } 





        //METHOD
        public static TimeSpan GetAverageBlockTime()
        {
            double sum = 0;
            for (int i = 1; i < Blocks.Count(); i++)
            {
                sum += Blocks[i].blockTime.TotalSeconds;
            }
            if (sum != 0)
            {
                return TimeSpan.FromSeconds(sum / (Blocks.Count() - 1));
            }
            else
            {
                return TimeSpan.FromSeconds(0);
            }
        }





        //METHOD
        public static TimeSpan GetAverageMineTime()
        {
            double sum = 0;
            for(int i = 1; i < Blocks.Count(); i++)
            {
                sum += Blocks[i].mineTime.TotalSeconds;
            }
            if (sum != 0)
            {
                return TimeSpan.FromSeconds(sum / (Blocks.Count() - 1));
            } else {
                return TimeSpan.FromSeconds(0);
            }
        }





        //METHOD
        public static double GetAverageMineRate()
        {
            double sum = 0;
            for(int i = 1; i < Blocks.Count(); i++)
            {
                sum += Blocks[i].nonce / Blocks[i].mineTime.TotalSeconds;
            }
            return (sum / (Blocks.Count()-1));
        }





        //METHOD
        public static TimeSpan GetPredictedBlockTime(int difficulty)
        {
            Console.WriteLine("16^"+difficulty.ToString()+": "+Math.Pow(16, difficulty));
            Console.WriteLine("Average Mine Rate: "+GetAverageMineRate());
            Console.WriteLine("Predicted Block Time: "+Math.Pow(16, difficulty)/GetAverageMineRate());

            return (TimeSpan.FromSeconds(Math.Pow(16,difficulty)/GetAverageMineRate()));
        }





        //METHOD
        public static void UpdateDifficulty()
        {
            TimeSpan targetBlockTime = TimeSpan.FromSeconds(1);
            int difficulty = 1;
            TimeSpan avgBlockTime = GetAverageBlockTime();
            double avgMineRate = GetAverageMineRate();
            TimeSpan predictedBlockTime;
            Console.WriteLine("Predicted Block Time: "+GetPredictedBlockTime(difficulty));

            if (avgBlockTime < targetBlockTime)             //if avgBlockTime needs to be increased to meet target:
            {
                Console.WriteLine("avgBlockTime "+avgBlockTime+" is SMALLER than targetBlockTime "+targetBlockTime+", needs increasing.");
                for (difficulty = 1; difficulty <= 13; difficulty++)        //loops starting from difficulty 1
                {
                    if (GetPredictedBlockTime(difficulty) > avgBlockTime)       //finds first difficulty that's average predicted block time that will increase the average block time
                    {
                        Console.WriteLine("difficulty "+difficulty+" has predicted block time "+
                            GetPredictedBlockTime(difficulty)+" which is GREATER than the average block time of "+avgBlockTime);
                        break;
                    }
                }
            } else if (avgBlockTime >= targetBlockTime)
            {
                Console.WriteLine("avgBlockTime "+avgBlockTime+" is GREATER THAN OR EQUAL TO targetBlockTime"+targetBlockTime+", needs decreasing.");
                for (difficulty = 13; difficulty >= 1; difficulty--)
                {
                    if(GetPredictedBlockTime(difficulty) < avgBlockTime)
                    {
                        Console.WriteLine("difficulty " + difficulty + " has predicted block time " +
                            GetPredictedBlockTime(difficulty) + " which is LESS than the average block time of " + avgBlockTime);
                        break;
                    }
                }
            }
            Console.WriteLine(difficulty);
            Block.difficulty = difficulty;
        }
    }
}
