Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dimcontrol()
        InitialiseJeu()
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click, btn10.Click, btn11.Click, btn12.Click
        Dim Numtrou As Byte = CByte(Mid(sender.name, 4))
        Dim continuer As Boolean
        Dim terminer As Boolean
        Jouer(Numtrou)
        terminer = JeuTermine()
        continuer = PeutJouer(Numtrou)
        If terminer = False Then
            If continuer = False Then
                MsgBox("Changer le joueur!")
                numjoueur(3 - joueur).Text = "Joueur" & (3 - joueur)
                numjoueur(joueur).Text = "→Joueur" & joueur
            End If
        Else
            MsgBox("Joueur " & (3 - joueur) & " est gagné !")
        End If
        validtrou(terminer, continuer, Numtrou)
    End Sub

    Private Sub btn_rj_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rj.Click
        InitialiseJeu()
    End Sub
End Class
