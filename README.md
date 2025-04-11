This document contains instructions and guidance on the functionality of the program.

PLEASE NOTE: CURRENCY CAN BECOME NEGATIVE AND THUS CREATED FROM NOTHING 
IN THIS VERSION OF THE PROGRAM FOR THE SAKE OF DEMONSTRATION.

*

*

____FUNCTIONS______________________________________________________________________________________________________________________________________________



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

*                         

*

*

*

____DEFINITIONS____________________________________________________________________________________________________________________________________________



PUBLIC KEY -       Identifies a wallet individually and uniquely publicly. Does not provide access to sensitive information alone. 

PRIVATE KEY -      Is linked mathematically via hashing to a PUBLIC KEY. In combination with the matching PUBLIC KEY, it acts as a password,
                   allowing access to the wallet and its information.

BLOCK TIME -       Amount of time it takes to add a new block to the chain.

MINE TIME -        Amount of time it ultimately took to mine a block.

MINE RATE -        Amount of hashes produced per second during mining.

BLOCKCHAIN -



<BLOCK 0>
------------------------------------------------------------------------------------------------------------------------------------------------------------

index: 0
previous hash: 
current hash: ed7b853be08e55e6cb8123317dba579d897bbb4388dccbbd9eee77a4ef6e0cf3
merkle root: 
difficulty: 4
nonce: 0
timestamp: 11/04/2025 10:05:18
mine time: 00:00:00
block time: 00:00:00


<BLOCK 1>
------------------------------------------------------------------------------------------------------------------------------------------------------------

index: 1
previous hash: ed7b853be08e55e6cb8123317dba579d897bbb4388dccbbd9eee77a4ef6e0cf3
current hash: 00008d990f7b8d694f9d6022e8129e8e777e2011791df8b28b86c718b5e3c5c9
merkle root: 0c22140fb39ed2afc7e6fa8edcfe37bae7c045dd093a27885fdd27f31acbba2f
difficulty: 4
nonce: 60720
timestamp: 11/04/2025 10:05:27
mine time: 00:00:00.6589649
block time: 00:00:09.4657309



TRANSACTION 1 -
Transaction Hash: 49714878b76a5ae5effd16d97e202a96c70190b636291cf17f286c6ddf53d93b
Digital Signature: S8V0DOV905Y8+7pYF6s2QhabWp2Nv1Ougnw/O36Gu5cGtHJQzTgshXpeBrzweVMqQM2eHskQmRK0rOTprjb2HA==

Transaction Amount: 12
Transaction Fee: 12

Sender Address: bz2q9OlclS0d6PD4DWWDHg5acs0C24KLT3sKIExkFnzArYrsWaBNzHJYajRT2YW0WjVCR6jlJGdSUKaUiN68Ug==
Receiver Address: bz2q9OlclS0d6PD4DWWDHg5acs0C24KLT3sKIExkFnzArYrsWaBNzHJYajRT2YW0WjVCR6jlJGdSUKaUiN68Ug==

Timestamp: 11/04/2025 10:05:25



TRANSACTION 2 -
Transaction Hash: e6acc9e140a6cd5bfc1ea8e2ef9949059520dc90c440bf04a5f37451f4c3f058
Digital Signature: null

Transaction Amount: 49
Transaction Fee: 0

Sender Address: Mining_Reward
Receiver Address: bz2q9OlclS0d6PD4DWWDHg5acs0C24KLT3sKIExkFnzArYrsWaBNzHJYajRT2YW0WjVCR6jlJGdSUKaUiN68Ug==

Timestamp: 11/04/2025 10:05:27






                
