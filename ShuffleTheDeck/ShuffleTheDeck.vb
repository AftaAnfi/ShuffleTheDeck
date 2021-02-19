Option Strict On
Option Explicit On
'Aftanom Anfilofieff
'RCET0265
'Spring 2021
'Shuffle The Deck
'https://github.com/AftaAnfi/ShuffleTheDeck.git
Module ShuffleTheDeck
    Dim cardSuits As String() = {"Spades", "Clubs", "Hearts", "Diamonds"}
    Dim cardNumbers As String() = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"}
    Dim drawnDeck(3, 12) As Boolean
    Dim randomSuit As Integer
    Dim randomNumber As Integer
    Dim tempUserInput As String
    Dim isRunning As Boolean = True


    Sub Main()
        'initialize randomize function
        Randomize()

        While isRunning
            Console.Clear()
            'prompt user
            Console.WriteLine("Press 1 to get a card, 2 to shuffle the deck and 3 to exit.")
            tempUserInput = Console.ReadLine()

            'get user input and decide what to do
            Select Case tempUserInput
                Case "1"
                    PickCard()
                Case "2"
                    'shuffle the deck
                    Console.WriteLine("Shuffling the deck...")
                    System.Threading.Thread.Sleep(1000)
                    ResetDrawnCards(drawnDeck)
                Case "3"
                    'exit the program
                    Console.WriteLine("Thanks for playing!")
                    System.Threading.Thread.Sleep(2000)
                    End

                Case Else
                    'prompt user that input was not 1, 2, or 3
                    Console.WriteLine($"That wasn't 1, 2, or 3. It was {tempUserInput}.")
            End Select


            Console.WriteLine("Press any key to continue...")
            Console.ReadKey(False)
        End While


    End Sub

    'sub to pick a random card and write it to the console
    Sub PickCard()
        'randomize the suit and number of the card
        randomSuit = CInt(Math.Floor(Rnd() * 4))
        randomNumber = CInt(Math.Floor(Rnd() * 13))

        'check to see if the deck has been drawn completely
        If CheckIfDeckIsAllDrawn(drawnDeck) = True Then
            Console.WriteLine("Deck has been all drawn")
            Console.WriteLine("resetting deck")
            System.Threading.Thread.Sleep(2000)
            'reset the deck and pick another card
            ResetDrawnCards(drawnDeck)
            PickCard()

        Else

            If drawnDeck(randomSuit, randomNumber) = True Then
                'if the random selected has been picked, use recursion and pick another one
                PickCard()

            Else
                'set the exact card to be drawn (true value in multidimensional array) and write the card to the console
                drawnDeck(randomSuit, randomNumber) = True
                Console.WriteLine($"{cardNumbers(randomNumber)} of {cardSuits(randomSuit)}")
            End If
        End If
    End Sub

    'function to check if the deck is fully drawn
    Function CheckIfDeckIsAllDrawn(ByRef drawnDeck As Boolean(,)) As Boolean
        'check all cards to see if any are false
        For l = 0 To drawnDeck.GetUpperBound(0)
            For f = 0 To drawnDeck.GetUpperBound(1)
                If drawnDeck(l, f) = False Then
                    'if one is false, return false
                    Return False
                End If
            Next
        Next
        'if loop does not return false, return true as the deck has been fully drawn
        Return True
    End Function

    'sub to reset the drawncard multidimensional array
    Sub ResetDrawnCards(ByRef drawndeck As Boolean(,))
        'loop through every component in array and set to false
        For l = 0 To drawndeck.GetUpperBound(0)
            For f = 0 To drawndeck.GetUpperBound(1)
                drawndeck(l, f) = False
            Next
        Next
    End Sub

End Module
