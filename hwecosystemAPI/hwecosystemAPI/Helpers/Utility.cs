using hwecosystemAPI.DTOs;
using hwecosystemAPI.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace hwecosystemAPI.Helpers
{
    public class Utility
    {

        public static byte[] ConvertToBytes(IFormFile image)
        {
            byte[] CoverImageBytes = null;
            BinaryReader reader = new BinaryReader(image.OpenReadStream());
            CoverImageBytes = reader.ReadBytes((int)image.Length);
            return CoverImageBytes;
        }

        public static Level[] SortListofLevels(List<Level> levels)
        {
            Level[] arr = levels.ToArray();
            Level temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    if (arr[i].Level_Index > arr[i + 1].Level_Index)
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr;
        }

        public static List<Cycle> SortListofCycles(List<Cycle> cycles)
        {
            Cycle[] arr = cycles.ToArray();
            Cycle temp;
            for (int j = 0; j <= arr.Length - 2; j++)
            {
                for (int i = 0; i <= arr.Length - 2; i++)
                {
                    DateTime cycleDate_i = new DateTime(arr[i].CreatedYear, arr[i].CreatedMonth, arr[i].CreatedDay);
                    DateTime cycleDate_iplusOne = new DateTime(arr[i + 1].CreatedYear, arr[i + 1].CreatedMonth, arr[i + 1].CreatedDay);

                    if (cycleDate_i > cycleDate_iplusOne)
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr.ToList();

        }

        public static int GetContributorsPerLevel(string Desendants_Ids)
        {
            var list = Desendants_Ids.Split("?");
            List<string> ans = new List<string>();
            for (int i = 0; i < list.Count(); i++)
            {

                if (list[i] == "" || string.IsNullOrEmpty(list[i]))
                    continue;

                ans.Add(list[i]);

            }

            return ans.Count;
        }

        public static List<Descendant> InitializeDescendants(int leveIndex)
        {
            int nCount = 3;

            if (leveIndex == 1) nCount = 3;
            else if (leveIndex == 2) nCount = 9;
            else if (leveIndex == 3) nCount = 27;
            else if (leveIndex == 4) nCount = 81;
            else if (leveIndex == 5) nCount = 243;
            else if (leveIndex == 6) nCount = 729;
            else if (leveIndex == 7) nCount = 2187;

            List<Descendant> descendants = new List<Descendant>();

            for (int i = 0; i < nCount; i++)
            {
                descendants.Add(new Descendant());
            }

            return descendants;
        }
        public static List<Guid> GetContributorsIdPerLevel(string Desendants_Ids)
        {
            List<Guid> ans = new List<Guid>();

            if (string.IsNullOrEmpty(Desendants_Ids) == true)
                return ans;

            var list = Desendants_Ids.Split("?");

            for (int i = 0; i < list.Count(); i++)
            {

                if (list[i] == "" || string.IsNullOrEmpty(list[i]))
                    continue;

                ans.Add(new Guid(list[i]));

            }

            return ans;
        }

        public static void GetTableOfPayments()
        {

        }

        public static List<RefugeCenter> SortListofEntryRefugee(List<RefugeCenter> refugeCenters)
        {
            List<RefugeCenter> arr = refugeCenters.ToList();
            RefugeCenter temp;
            int n = arr.Count;

            for (int j = 0; j <= n - 2; j++)
            {
                for (int i = 0; i <= n - 2; i++)
                {
                    if (arr[i].contributorIndex > arr[i + 1].contributorIndex)
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr.ToList();
        }

        public static List<RefugeCenterModel> SortListofRefugeeCenterModel(List<RefugeCenterModel> refugeCenters)
        {
            List<RefugeCenterModel> arr = refugeCenters.ToList();
            RefugeCenterModel temp;
            int n = arr.Count;

            for (int j = 0; j <= n - 2; j++)
            {
                for (int i = 0; i <= n - 2; i++)
                {
                    if (arr[i].contributorIndex > arr[i + 1].contributorIndex)
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr.ToList();
        }

        //public static List<RefugeCenter> Re_NumberListofEntryRefugee(List<RefugeCenter> refugeCenters)
        //{
        //    List<RefugeCenter> arr = refugeCenters.ToList();
        //    int n = arr.Count;
        //    for (int j = 0; j < n; j++)
        //    {
        //        arr[j].contributorIndex = j + 1;
        //    }

        //    return arr;
        //}

        public static List<Pishon> SortListofPishon(List<Pishon> pishons)
        {
            List<Pishon> arr = pishons.ToList();
            Pishon temp;
            int n = arr.Count;

            for (int j = 0; j <= n - 2; j++)
            {
                for (int i = 0; i <= n - 2; i++)
                {
                    if (arr[i].contributorIndex > arr[i + 1].contributorIndex)
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr.ToList();
        }

        public static List<Pishon> Re_NumberListofPhison(List<Pishon> refugeCenters)
        {
            List<Pishon> arr = refugeCenters.ToList();
            int n = arr.Count;
            for (int j = 0; j < n; j++)
            {
                arr[j].ActualPishonIndex = j + 1;
            }

            return arr;
        }

        public static Contributor FindContributorById(List<Contributor> contributors, Guid id)
        {
            Contributor user = null;

            foreach (var item in contributors)
            {
                if (item.Id == id)
                {
                    user = item;
                    return user;
                }
            }
            return null;
        }

        public static Account FindAccountByContributorId(List<Account> accounts, Guid contributorId)
        {
            Account account = null;

            foreach (var item in accounts)
            {
                if (item.Contributor_Id == contributorId)
                {
                    account = item;
                    return account;
                }
            }
            return null;
        }

        public static RefugeCenter FindRefugeCenterByContributorId(List<RefugeCenter> RefugeCenters, Guid contributorId)
        {
            RefugeCenter refugeCenter = null;

            foreach (var item in RefugeCenters)
            {
                if (item.contributorId == contributorId)
                {
                    refugeCenter = item;
                    return refugeCenter;
                }
            }
            return null;
        }



        public static Tuple<List<RefugeCenter>, List<RefugeCenter>> CreateListOfEntryRefugee(List<RefugeCenter> mainrefugeCenters,
                                                                List<Contributor> contributors, int freeSpacePishon,
                                                                List<Account> accounts)
        {
            List<RefugeCenter> qualifiedRefugees = new List<RefugeCenter>();
            int i = 0, mainrefugeCentersCount = mainrefugeCenters.Count;

            //Get all refugees with nChildren > 0 or nGrandChildren > 0
            for (i = 0; i < mainrefugeCentersCount; i++)
            {
                var contributor = FindContributorById(contributors, mainrefugeCenters[i].contributorId);
                var account = FindAccountByContributorId(accounts, mainrefugeCenters[i].contributorId);

                if (contributor.nChildren >= 3 && account.IsComfirmed == true)
                {
                    if (qualifiedRefugees.Contains(mainrefugeCenters[i]) == false)
                    {
                        qualifiedRefugees.Add(mainrefugeCenters[i]);
                    }
                }


                if (qualifiedRefugees.Count == freeSpacePishon)
                    return new Tuple<List<RefugeCenter>, List<RefugeCenter>>(qualifiedRefugees, mainrefugeCenters);
            }

            int qualifiedRefugeesCount = qualifiedRefugees.Count;

            for (i = 0; i < qualifiedRefugeesCount; i++)
            {
                if (mainrefugeCenters.Contains(qualifiedRefugees[i]) == true)
                {
                    mainrefugeCenters.Remove(qualifiedRefugees[i]);

                }
            }

            #region unsed codes


            //mainrefugeCentersCount = mainrefugeCenters.Count;
            ////mainrefugeCenters.Count < freeSpacePishon
            //for (i = 0; i < mainrefugeCentersCount; i++)
            //{
            //    var account = FindAccountByContributorId(accounts, mainrefugeCenters[i].contributorId);
            //    if (account != null)
            //    {
            //        if (qualifiedRefugees.Contains(mainrefugeCenters[i]) == false && account.IsComfirmed == true)
            //        {
            //            qualifiedRefugees.Add(mainrefugeCenters[i]);
            //        }
            //    }


            //    if (qualifiedRefugees.Count == freeSpacePishon) break;
            //}

            //qualifiedRefugeesCount = qualifiedRefugees.Count;

            //for (i = 0; i < qualifiedRefugeesCount; i++)
            //{
            //    if (mainrefugeCenters.Contains(qualifiedRefugees[i]) == true)
            //    {
            //        mainrefugeCenters.Remove(qualifiedRefugees[i]);

            //    }
            //}

            #endregion

            return new Tuple<List<RefugeCenter>, List<RefugeCenter>>(qualifiedRefugees, mainrefugeCenters);
        }

        public static int GetRefugeMaxIndex(List<RefugeCenter> refugeCenters)
        {
            int RefugeMaxIndex = 1, userCount = refugeCenters.Count();
            for (int i = 0; i < userCount; i++)
            {
                if (refugeCenters[i].contributorIndex > RefugeMaxIndex)
                {
                    RefugeMaxIndex = refugeCenters[i].contributorIndex;
                }
            }

            return RefugeMaxIndex;

        }

        public static int GetPishonMaxIndex(List<Pishon> pishons)
        {
            int PishonMaxIndex = 1, userCount = pishons.Count();
            for (int i = 0; i < userCount; i++)
            {
                if (pishons[i].contributorIndex > PishonMaxIndex)
                {
                    PishonMaxIndex = pishons[i].contributorIndex;
                }
            }

            return PishonMaxIndex;

        }

        public static int GetPishoRefugeenMaxIndex(List<PishonRefugeeCenter> pishonRefugees)
        {
            int PishonRefugeeMaxIndex = 1, userCount = pishonRefugees.Count();
            for (int i = 0; i < userCount; i++)
            {
                if (pishonRefugees[i].contributorIndex > PishonRefugeeMaxIndex)
                {
                    PishonRefugeeMaxIndex = pishonRefugees[i].contributorIndex;
                }
            }

            return PishonRefugeeMaxIndex;

        }
        public static Tuple<List<Pishon>, List<Pishon>> CreateListOfPishons(List<Pishon> Pishons, List<Contributor> contributors)
        {
            List<Pishon> qualifiedPishons = new List<Pishon>();
            int i = 0, PishonsCount = Pishons.Count;

            //Get all pishons with all Entitlements Paid  
            // and 
            for (i = 0; i < PishonsCount; i++)
            {
                var contributor = FindContributorById(contributors, Pishons[i].contributorId);

                if (Pishons[i].isLevelSevenEntitlementPaid == true && contributor.nChildren >= 3 &&
                    contributor.nGrandChildren >= 9)
                {
                    qualifiedPishons.Add(Pishons[i]);
                }
            }

            int qualifiedPishonsCount = qualifiedPishons.Count;
            for (i = 0; i < qualifiedPishonsCount; i++)
            {

                if (Pishons.Contains(qualifiedPishons[i]) == true )
                {
                    Pishons.Remove(qualifiedPishons[i]);
                }
            }

            return new Tuple<List<Pishon>, List<Pishon>>(qualifiedPishons, Pishons);
        }


        public static List<PishonRefugeeCenter> SortListofPishonRefugee(List<PishonRefugeeCenter> refugeCenters)
        {
            List<PishonRefugeeCenter> arr = refugeCenters.ToList();
            PishonRefugeeCenter temp;
            int n = arr.Count;

            for (int j = 0; j <= n - 2; j++)
            {
                for (int i = 0; i <= n - 2; i++)
                {
                    if (arr[i].contributorIndex > arr[i + 1].contributorIndex)
                    {
                        temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr.ToList();
        }

        //public static List<PishonRefugeeCenter> Re_NumberListofPishonRefugee(List<PishonRefugeeCenter> refugeCenters)
        //{
        //    List<PishonRefugeeCenter> arr = refugeCenters.ToList();
        //    int n = arr.Count;
        //    for (int j = 0; j < n; j++)
        //    {
        //        arr[j].contributorIndex = j + 1;
        //    }

        //    return arr;
        //}

        public static Pishon FindPishonByContributorId(List<Pishon> pishons, Guid contributorId)
        {
            Pishon pishon = null;

            foreach (var item in pishons)
            {
                if (item.contributorId == contributorId)
                {
                    pishon = item;
                    return pishon;
                }
            }
            return null;
        }

        //public static Account FindAccountByContributorId(List<Account> accounts, Guid contributorId)
        //{
        //    Account account = null;

        //    foreach (var item in accounts)
        //    {
        //        if (item.Contributor_Id == contributorId)
        //        {
        //            account = item;
        //            return account;
        //        }
        //    }
        //    return null;
        //}

        public static Tuple<List<Pishon>, bool, bool> GetPishonsByLevel(int levelIndex, Pishon activePishon, List<Pishon> old_pishons)
        {
            var _pishons = Re_NumberListofPhison(old_pishons);

            int _pishonCount = _pishons.Count();
            List<Pishon> pishons = new List<Pishon>();
            int counter = 0, counter2 = 0;
            int activePishonPosition = activePishon.ActualPishonIndex;
            bool isLevelCompleted = false;
            bool isLevelEntitlementPaid = false;
            switch (levelIndex)
            {
                case 1:
                    isLevelCompleted = activePishon.isLevelOneComplete;
                    isLevelEntitlementPaid = activePishon.isLevelOneEntitlementPaid;
                    for (int i = activePishonPosition; i < _pishonCount; i++)
                    {
                        counter++;
                        pishons.Add(_pishons[i]);
                        if (counter == 3) break;

                    }
                    break;

                case 2:
                    isLevelCompleted = activePishon.isLevelTwoComplete;
                    isLevelEntitlementPaid = activePishon.isLevelTwoEntitlementPaid;
                    for (int i = activePishonPosition; i < _pishonCount; i++)
                    {
                        counter++;

                       if(counter > 3)
                       {
                            counter2++;
                            pishons.Add(_pishons[i]);
                            if (counter2 == 9) break;
                       }
                       
                       



                    }
                    break;

                case 3:
                    isLevelCompleted = activePishon.isLevelThreeComplete;
                    isLevelEntitlementPaid = activePishon.isLevelThreeEntitlementPaid;
                    for (int i = activePishonPosition; i < _pishonCount; i++)
                    {
                        counter++;

                        if (counter > 12)
                        {
                            counter2++;
                            pishons.Add(_pishons[i]);
                            if (counter2 == 27) break;
                        }
                        



                    }
                    break;

                case 4:
                    isLevelCompleted = activePishon.isLevelFourComplete;
                    isLevelEntitlementPaid = activePishon.isLevelFourEntitlementPaid;
                    for (int i = activePishonPosition; i < _pishonCount; i++)
                    {
                        counter++;

                        if (counter > 39)
                        {
                            counter2++;
                            pishons.Add(_pishons[i]);
                            if (counter2 == 81) break;
                        }
                        



                    }
                    break;

                case 5:
                    isLevelCompleted = activePishon.isLevelFiveComplete;
                    isLevelEntitlementPaid = activePishon.isLevelFiveEntitlementPaid;
                    for (int i = activePishonPosition; i < _pishonCount; i++)
                    {
                        counter++;

                        if (counter > 120)
                        {
                            counter2++;
                            pishons.Add(_pishons[i]);
                            if (counter2 == 243) break;
                        }
                        



                    }
                    break;

                case 6:
                    isLevelCompleted = activePishon.isLevelSixComplete;
                    isLevelEntitlementPaid = activePishon.isLevelSixEntitlementPaid;
                    for (int i = activePishonPosition; i < _pishonCount; i++)
                    {
                        counter++;

                        if (counter > 363)
                        {
                            counter2++;
                            pishons.Add(_pishons[i]);
                            if (counter2 == 729) break;
                        }
                       



                    }
                    break;


                case 7:
                    isLevelCompleted = activePishon.isLevelSevenComplete;
                    isLevelEntitlementPaid = activePishon.isLevelSevenEntitlementPaid;
                    for (int i = activePishonPosition; i < _pishonCount; i++)
                    {
                        counter++;

                        if (counter > 1092)
                        {
                            counter2++;
                            pishons.Add(_pishons[i]);
                            if (counter2 == 2187) break;
                        }
                       



                    }
                    break;
            }


            return new Tuple<List<Pishon>, bool, bool>(pishons, isLevelCompleted, isLevelEntitlementPaid);
        }

        public static List<Models.Stream> GetListOfStream()
        {
            List<string> StreamNames = Constants.Streams;
            List<int> LevelCounts = Constants.LevelCounts;

            List<Models.Stream> streams = new List<Models.Stream>();
            Models.Stream stream = null;

            for (int i = 0; i < StreamNames.Count; i++)
            {
                stream = new Models.Stream();

                stream.Id = i + 1;
                stream.label = StreamNames[i];


                List<PsuedoLevel> children = new List<PsuedoLevel>();
                PsuedoLevel psuedoLevel = null;

                int LevelCount = LevelCounts[i];

                for (int j = 0; j < LevelCount; j++)
                {
                    psuedoLevel = new PsuedoLevel
                    {
                        Id = (j + 1).ToString() + "-" + StreamNames[i],
                        label = "Level-" + (j + 1).ToString(),
                    };
                    children.Add(psuedoLevel);

                }

                stream.children = children;

                streams.Add(stream);

            }

            return streams;
        }

        public static List<Models.Stream> GetPishonStream()
        {
            List<string> StreamNames = Constants.Streams;
            List<int> LevelCounts = Constants.LevelCounts;
            int levelIndex = 0;
            string streamName = StreamNames[levelIndex];
            List<Models.Stream> streams = new List<Models.Stream>();
            Models.Stream stream = null;


            stream = new Models.Stream();

            stream.Id = levelIndex + 1;
            stream.label = streamName;


            List<PsuedoLevel> children = new List<PsuedoLevel>();
            PsuedoLevel psuedoLevel = null;

            int LevelCount = LevelCounts[levelIndex];

            for (int j = 0; j < LevelCount; j++)
            {
                psuedoLevel = new PsuedoLevel
                {
                    Id = (j + 1).ToString() + "-" + streamName,
                    label = "Level-" + (j + 1).ToString(),
                };
                children.Add(psuedoLevel);

            }

            stream.children = children;

            streams.Add(stream);


            return streams;
        }

        public static int GetActualPishonIndex(List<Pishon> pishons, int fakePishonIndex)
        {
            var _pishons = pishons.ToList();
            _pishons = SortListofPishon(_pishons);
            _pishons = Re_NumberListofPhison(_pishons);
            int indexpishon = 1;
            int _pishonsCount = _pishons.Count;

            for (int i = 0; i < _pishonsCount; i++)
            {
                if (_pishons[i].contributorIndex == fakePishonIndex)
                {
                    indexpishon = _pishons[i].ActualPishonIndex;
                    return indexpishon;
                }
            }

            return indexpishon;

        }

        public static List<Account> SortListofAccount(List<Account> _accounts, List<RefugeCenter> refugeCenters)
        {
            List<Account> accounts = new List<Account>();
            
            int refugeCentersCount = refugeCenters.Count;
            int _accountsCount = _accounts.Count;

            for (int j = 0; j < refugeCentersCount; j++)
            {
                for (int i = 0; i < _accountsCount; i++)
                {
                    if (refugeCenters[j].contributorId == _accounts[i].Contributor_Id)
                    {
                        accounts.Add(_accounts[i]);
                    }
                }
            }

            return accounts;
        }
    }
}
