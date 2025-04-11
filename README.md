This document contains instructions and guidance on the functionality of the program.

PLEASE NOTE: CURRENCY CAN BECOME NEGATIVE AND THUS CREATED OUT OF THIN AIR IN THIS VERSION OF THE PROGRAM FOR THE SAKE OF DEMONSTRATION.


____FUNCTIONS____________________________________________________________________________________________________________________________________________________



GENERATE WALLET -  Generates a mathematically matching PUBLIC KEY and PRIVATE KEY that, in unison, connects to a banking account that includes a balance and transaction history.

CHECK BALANCE -    Considering that the correct PUBLIC KEY and PRIVATE KEY are filled in, this button returns a wallet's public ID, account balance and transaction history.

PRINT PENDING TRANSACTIONS -   This returns a list of all of the transactions that have been sent and are pending, but not mined into the BLOCKCHAIN yet. 

VALIDATE KEYS -    Verifies that the mathematical hashing link between a given PUBLIC KEY and PRIVATE KEY is valid (testing). 

VALIDATE BLOCKCHAIN -    Verifies that the mathematical hashing links in the BLOCKCHAIN are valid (testing).      

BLOCK TIME -       Returns average BLOCK TIME, average MINE TIME and average MINE RATE values.

PRINT BLOCK -      Returns the information of the specified block number.

PRINT ALL -        Returns all of the blocks and their information.

GENERATE BLOCK -   Starts mining of up to 5 transactions at a time (note there is always a single additional transaction that wires the rewards to the miner upon mining completion).

ALTRUISTIC MINING -      This switches the transaction selection algorithm from the transaction pool (when mining) to choose using FIFO (First In, First Out). This is the standard setting.

RANDOM MINING -          This switches the transaction selection algorithm from the transaction pool (when mining) to choose pseudorandomly.

GREEDY MINING -          This switches the transaction selection algorithm from the transaction pool (when mining) to choose the transactions with the highest rewards.

ADDRESSED MINING -       This switches the transaction selection algorithm from the transaction pool (when mining) to choose only transactions that are to the given Receiver Address 
                         (receiver public key).

SEND TRANSACTION -       Sends a valid transaction to the transaction pool, ready to be mined. Valid includes a valid wallet (valid Public and Private Key pair), valid Receiver Key
                         (this is the receiver's wallets' Public Key), sufficient sender funds, and valid Amount and Fee values.

                         







____DEFINITIONS__________________________________________________________________________________________________________________________________________________



PUBLIC KEY -       Identifies a wallet individually and uniquely publicly. Does not provide access to sensitive information alone. 

PRIVATE KEY -      Is linked mathematically via hashing to a PUBLIC KEY. In combination with the matching PUBLIC KEY, it acts as a password,
                   allowing access to the wallet and its information.

BLOCK TIME -       Amount of time it takes to add a new block to the chain.

MINE TIME -        Amount of time it ultimately took to mine a block.

MINE RATE -        Amount of hashes produced per second during mining.

BLOCKCHAIN -



                
