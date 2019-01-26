Module Module1
    Public trou(12) As Integer
    Public cases(12) As Byte
    Public valid As Boolean
    Public button(12) As Button
    Public score(2) As Label
    Public numjoueur(2) As Label
    Public grains As Byte
    Public joueur As Byte
    Public Sub dimcontrol()
        button(1) = Form1.btn1
        button(2) = Form1.btn2
        button(3) = Form1.btn3
        button(4) = Form1.btn4
        button(5) = Form1.btn5
        button(6) = Form1.btn6
        button(7) = Form1.btn7
        button(8) = Form1.btn8
        button(9) = Form1.btn9
        button(10) = Form1.btn10
        button(11) = Form1.btn11
        button(12) = Form1.btn12

        score(1) = Form1.lblscore_j1
        score(2) = Form1.lblscore_j2

        numjoueur(1) = Form1.lblj1
        numjoueur(2) = Form1.lblj2
    End Sub

    Public Sub InitialiseJeu()
        For i = 1 To 12
            trou(i) = 4
            button(i).Text = trou(i)
        Next i

        score(1).Text = 0
        score(2).Text = 0
        joueur = 1
        numjoueur(joueur).Text = "→Joueur" & joueur
        numjoueur(3 - joueur).Text = "Joueur" & (3 - joueur)
        For j = 1 To 6
            button(j).Enabled = True
        Next
        For j = 7 To 12
            button(j).Enabled = False
        Next

    End Sub

    Public Sub Jouer(ByVal i As Integer)
        Dim j As Integer
        grains = trou(i)
        trou(i) = 0
        If i + grains - 1 <= 12 Then
            For j = i + 1 To i + grains - 1
                trou(j) = trou(j) + 1
            Next
        Else
            For j = i + 1 To 12
                trou(j) = trou(j) + 1
            Next
            For j = 1 To (grains - 1) - (12 - i)
                trou(j) = trou(j) + 1
            Next
        End If
        For i = 1 To 12
            button(i).Text = trou(i)
        Next
        score(joueur).Text = CByte(score(joueur).Text) + 1
    End Sub

    Public Function PeutJouer(ByVal i As Integer) As Boolean
        Dim continuer As Boolean = True
        Dim j As Byte
        If i + grains - 1 <= 11 Then
            j = i + grains
            If trou(j) = 0 Then
                If joueur = 1 Then
                    If Not (button(7).Text = 0 And button(8).Text = 0 And button(9).Text = 0 And button(10).Text = 0 And button(11).Text = 0 And button(12).Text = 0) Then
                        continuer = False
                        joueur = 3 - joueur
                    End If
                Else
                    If Not (button(1).Text = 0 And button(2).Text = 0 And button(3).Text = 0 And button(4).Text = 0 And button(5).Text = 0 And button(6).Text = 0) Then
                        continuer = False
                        joueur = 3 - joueur
                    End If
                End If
            End If
        Else
            j = grains - (12 - i)
            If trou(j) = 0 Then
                continuer = False
                If joueur = 1 Then
                    If Not (button(7).Text = 0 And button(8).Text = 0 And button(9).Text = 0 And button(10).Text = 0 And button(11).Text = 0 And button(12).Text = 0) Then
                        joueur = 3 - joueur
                    End If
                Else
                    If Not (button(1).Text = 0 And button(2).Text = 0 And button(3).Text = 0 And button(4).Text = 0 And button(5).Text = 0 And button(6).Text = 0) Then
                        joueur = 3 - joueur
                    End If
                End If
            End If
        End If

        Return continuer
    End Function

    Public Function JeuTermine() As Boolean
        Dim termine As Boolean = False
        If CByte(score(joueur).Text) > 24 Then
            termine = True
        End If
        Return termine
    End Function

    Public Sub validtrou(ByVal termine As Boolean, ByVal continuer As Boolean, ByVal i As Integer)
        If termine = False Then
            If continuer = True Then
                For j = 1 To 12
                    button(j).Enabled = False
                Next
                If i + grains - 1 <= 11 Then
                    button(i + grains).Enabled = True
                Else
                    button(grains - (12 - i)).Enabled = True
                End If
            Else
                If joueur = 1 Then
                    For j = 1 To 6
                        If button(j).Text <> 0 Then
                            button(j).Enabled = True
                        Else
                            button(j).Enabled = False
                        End If
                    Next
                    For j = 7 To 12
                        button(j).Enabled = False
                    Next
                Else
                    For j = 1 To 6
                        button(j).Enabled = False
                    Next
                    For j = 7 To 12
                        If button(j).Text <> 0 Then
                            button(j).Enabled = True
                        Else
                            button(j).Enabled = False
                        End If
                    Next
                End If
            End If
        Else
            For j = 1 To 12
                button(j).Enabled = False
            Next
        End If
    End Sub
End Module
