﻿using System;
using System.Diagnostics;
using System.Windows.Forms;
using BigTycoon.Generale;

namespace BigTycoon.GestioneDipendenti
{
    public class Dipendenti
    {
        public int Quantita { get; private set; }
        public int MinimoDipendenti { get; set; }
        public int MassimoDipendenti { get; set; }
        public int StipendiPerc { get; private set; }
        public int StipendioBase { get; set; }
        public int Felicita { get; internal set; }
        public double Stipendio
        {
            get => ((float)StipendioBase / 100.0f) * StipendiPerc * Quantita;
        }

        public Dipendenti(int minimoDipendenti, int massimoDipendenti, int stipendioBase)
        {
            Quantita = 0;
            MinimoDipendenti = minimoDipendenti;
            MassimoDipendenti = massimoDipendenti;
            StipendiPerc = 100;
            StipendioBase = stipendioBase;
            Felicita = 0;
        }

        public void AggiungiDipendenti(Giocatore gio)
        {
            if (gio.DipendentiDisponibili > 0 && Quantita < MassimoDipendenti)
            {
                gio.DipendentiDisponibili--;
                Quantita++;
            }
        }

        public void RimuoviDipendenti(Giocatore gio)
        {
            if (Quantita > 0)
            {
                Quantita--;
                gio.DipendentiDisponibili++;
            }
        }

        public void ModStipendi(int mod)
        {
            StipendiPerc += mod;

            if (StipendiPerc < 50)
            {
                StipendiPerc = 50;
            }
            else if (StipendiPerc > 200)
            {
                StipendiPerc = 200;
            }
        }

        public void AumentaFelicita(int n)
        {
            Felicita += n;
        }

        public void DiminuisciFelicita(int n)
        {
            Felicita -= n;
        }
    }
}
