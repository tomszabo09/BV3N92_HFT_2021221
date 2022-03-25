using BV3N92_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BV3N92_GUI_2021222.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private Parliament selectedParliament;
        private Party selectedParty;
        private PartyMember selectedPartyMember;
        public List<Party> IdeologyParties { get; set; }

        public Parliament SelectedParliament
        {
            get { return selectedParliament; }
            set
            {
                if (value != null)
                {
                    selectedParliament = new Parliament() { ParliamentName = value.ParliamentName, ParliamentID = value.ParliamentID, RulingParty = value.RulingParty };
                    selectedParty = Parties.FirstOrDefault(x => x.ParliamentID == value.ParliamentID);
                    OnPropertyChanged();
                    (CreateParliamentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateParliamentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteParliamentCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public Party SelectedParty
        {
            get { return selectedParty; }
            set
            {
                if (value != null)
                {
                    selectedParty = new Party() { PartyName = value.PartyName, PartyID = value.PartyID, ParliamentID = value.ParliamentID, Ideology = value.Ideology };
                    OnPropertyChanged();
                    (CreatePartyCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdatePartyCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeletePartyCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public PartyMember SelectedPartyMember
        {
            get { return selectedPartyMember; }
            set
            {
                if (value != null)
                {
                    selectedPartyMember = new PartyMember() { LastName = value.LastName, MemberID = value.MemberID, Age = value.Age, PartyID = value.PartyID };
                    OnPropertyChanged();
                    (CreatePartyMemberCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdatePartyMemberCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeletePartyMemberCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public RestCollection<Parliament> Parliaments { get; set; }
        public RestCollection<Party> Parties { get; set; }
        public RestCollection<PartyMember> PartyMembers { get; set; }

        public ICommand CreateParliamentCommand { get; set; }
        public ICommand CreatePartyCommand { get; set; }
        public ICommand CreatePartyMemberCommand { get; set; }
        public ICommand UpdateParliamentCommand { get; set; }
        public ICommand UpdatePartyCommand { get; set; }
        public ICommand UpdatePartyMemberCommand { get; set; }
        public ICommand DeleteParliamentCommand { get; set; }
        public ICommand DeletePartyCommand { get; set; }
        public ICommand DeletePartyMemberCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Parliaments = new RestCollection<Parliament>("http://localhost:41126/", "parliament", "hub");
                Parties = new RestCollection<Party>("http://localhost:41126/", "party", "hub");
                PartyMembers = new RestCollection<PartyMember>("http://localhost:41126/", "partymember", "hub");

                IdeologyParties = new List<Party>();
                IdeologyParties.Add(new Party() { Ideology = Ideologies.Socialist.ToString() });
                IdeologyParties.Add(new Party() { Ideology = Ideologies.Conservative.ToString() });
                IdeologyParties.Add(new Party() { Ideology = Ideologies.Nationalist.ToString() });

                CreateParliamentCommand = new RelayCommand(() =>
                {
                    Parliaments.Add(new Parliament()
                    {
                        ParliamentName = SelectedParliament.ParliamentName,
                        RulingParty = SelectedParliament.RulingParty
                    });
                }, () => { return SelectedParliament != null; });

                CreatePartyCommand = new RelayCommand(() =>
                {
                    Parties.Add(new Party()
                    {
                        PartyName = SelectedParty.PartyName,
                        ParliamentID = SelectedParty.ParliamentID,
                        Ideology = SelectedParty.Ideology
                    });
                }, () => { return SelectedParty != null; });

                CreatePartyMemberCommand = new RelayCommand(() =>
                {
                    PartyMembers.Add(new PartyMember()
                    {
                        Age = SelectedPartyMember.Age,
                        LastName = SelectedPartyMember.LastName,
                        PartyID = SelectedPartyMember.PartyID
                    });
                }, () => { return SelectedPartyMember != null; });

                UpdateParliamentCommand = new RelayCommand(() => { Parliaments.Update(SelectedParliament); }, () => { return SelectedParliament != null; });

                UpdatePartyCommand = new RelayCommand(() => { Parties.Update(SelectedParty); }, () => { return SelectedParty != null; });

                UpdatePartyMemberCommand = new RelayCommand(() => { PartyMembers.Update(SelectedPartyMember); }, () => { return SelectedPartyMember != null; });

                DeleteParliamentCommand = new RelayCommand(() =>
                {
                    Parliaments.Delete(SelectedParliament.ParliamentID);
                }, () => { return SelectedParliament != null; });

                DeletePartyCommand = new RelayCommand(() =>
                {
                    Parties.Delete(SelectedParty.PartyID);
                }, () => { return SelectedParty != null; });

                DeletePartyMemberCommand = new RelayCommand(() =>
                {
                    PartyMembers.Delete(SelectedPartyMember.MemberID);
                }, () => { return SelectedPartyMember != null; });

                //SelectedParliament = new Parliament();
                //SelectedParty = new Party();
                //SelectedPartyMember = new PartyMember();
            }
        }
    }
}
