Module Cards
    Sub Main()
        Dim cardDeck(3, 12) As Boolean
        Dim Suit As Integer
        Dim Card As Integer
        Dim trys As Integer

        For i = 0 To 75

            'cardDeck(Suit, Card) = True
            'test if card has already been drawn
            'yes - do nothing and try again
            'no - mark the element in table true and display

            Do
                trys += 1
                Suit = RandomNumberInRange(3)
                Card = RandomNumberInRange(12)
            Loop While cardDeck(Suit, Card) = True

            cardDeck(Suit, Card) = True

            Console.Clear()
            ShowDeltHand(cardDeck)
            ' Console.WriteLine($"draw {i} took {trys} trys") 'Take out comment if user desires to see how many interations the code ran to find Card
            trys = 0 'Reset to 0
            Console.ReadLine()

        Next

        ShowDeltHand(cardDeck)
        Console.Read() 'Press enter to draw card
    End Sub

    Sub ShowDeltHand(ByRef Deck(,) As Boolean)
        Dim header() As String = {"Spade", "Clubs", "Hearts", "Diamonds"}
        Dim columnWidth As Integer = 8

        Dim columnData As String

        For row = 0 To Deck.GetLength(1)
            For column = 0 To Deck.GetLength(0) - 1
                Select Case row
                    Case 0
                        columnData = header(column).PadLeft(columnWidth)
                    Case Else
                        If Not Deck(column, row - 1) Then ' mark drawn Card
                            columnData = "  "
                            ' Code returns only integers but the code requires an ACE, JACK, QUEEN, KING
                            'If Card is 'x' then change columData to appropriate card value
                        Else
                            columnData = CStr(row)
                            If row = 11 Then
                                columnData = ("Jack")
                            ElseIf row = 12 Then
                                columnData = ("Queen")
                            ElseIf row = 13 Then
                                columnData = ("King")
                            ElseIf row = 1 Then
                                columnData = ("ACE")
                            End If
                        End If
                End Select
                Console.Write(CStr(columnData.PadLeft(columnWidth) & " |"))
            Next
            Console.WriteLine()
            ' Console.WriteLine(StrDup(25, "-"))
        Next

    End Sub


    'This function returns a random Card based on the miliseconds of the clock, did not write this 
    ''' <summary>
    ''' The default range is 0 - 10.
    ''' The maximum number must be greater than minimum number.
    ''' </summary>
    ''' <param name="max%"></param>
    ''' <param name="min%"></param>
    ''' <returns>Returns a random integer within a range defined by the max and min arguments.</returns>
    ''' <exception cref="System.ArgumentException">Thrown when <c>max > min</c></exception>
    Function RandomNumberInRange(Optional max% = 10%, Optional min% = 0%) As Integer ' % is shorthand for integer
        Dim _max% = max - min
        If _max < 0 Then
            Throw New System.ArgumentException("Maximum Card must be greater than minimum Card")
        End If
        Randomize(DateTime.Now.Millisecond)
        Return CInt(System.Math.Floor(Rnd() * (_max + 1))) + min
    End Function

End Module
