using AcneTeledermatology.Models;

namespace AcneTeledermatology.Data
{
    public static class DbInitializer

    {


        //public static void Initialize(AcneTeleContext context)
        //{
        //    // Look for any users.
        //    if (context.Users.Any())
        //    {
        //        return;   // DB has been seeded
        //    }

        //    var users = new User[]
        //    {
        //        new User{IDUser = 1, DateCreated=DateTime.Parse("2019-09-01")},
        //        new User{IDUser = 2, DateCreated=DateTime.Parse("2019-09-01")},
        //        new User{IDUser = 3, DateCreated=DateTime.Parse("2019-09-01")},
        //        new User{IDUser = 4, DateCreated=DateTime.Parse("2019-09-01")},
        //        new User{IDUser = 5, DateCreated=DateTime.Parse("2019-09-01")},
        //        new User{IDUser = 6, DateCreated=DateTime.Parse("2019-09-01")}

        //    };

        //    context.Users.AddRange(users);
        //    context.SaveChanges();

        //    var userprofiles = new UserProfile[]
        //    {
        //        new UserProfile{IDUserProfile = 10, IDUser = 1, Username = "user_1", Password = "abc123", ProfileImagePath = ""},
        //        new UserProfile{IDUserProfile = 11, IDUser = 2, Username = "user_2", Password = "abc123", ProfileImagePath = ""},
        //        new UserProfile{IDUserProfile = 12, IDUser = 3, Username = "user_3", Password = "abc123", ProfileImagePath = ""},
        //        new UserProfile{IDUserProfile = 13, IDUser = 4, Username = "user_4", Password = "abc123", ProfileImagePath = ""},
        //        new UserProfile{IDUserProfile = 14, IDUser = 5, Username = "user_5", Password = "abc123", ProfileImagePath = ""},
        //        new UserProfile{IDUserProfile = 15, IDUser = 6, Username = "user_6", Password = "abc123", ProfileImagePath = ""}

        //    };

        //    context.UserProfiles.AddRange(userprofiles);
        //    context.SaveChanges();

        //    var usersupplementalacneprofiles = new UserSupplementalAcneProfile[]
        //  {
        //      new UserSupplementalAcneProfile{IDUserSupplementalAcneProfile = 101, IDUser = 1, SleepingPattern = 3, SunblockHabit = 3, DietHabit = 2, SkincareProducts = "sunscreen, serum, toner, essence, sheet mask", SunExposure = 1},
        //      new UserSupplementalAcneProfile{IDUserSupplementalAcneProfile = 102, IDUser = 2, SleepingPattern = 4, SunblockHabit = 2, DietHabit = 1, SkincareProducts = "sunscreen, serum, toner, essence, sheet mask", SunExposure = 2},
        //      new UserSupplementalAcneProfile{IDUserSupplementalAcneProfile = 103, IDUser = 3, SleepingPattern = 5, SunblockHabit = 1, DietHabit = 1, SkincareProducts = "sunscreen, serum, toner, essence, sheet mask", SunExposure = 3},
        //      new UserSupplementalAcneProfile{IDUserSupplementalAcneProfile = 104, IDUser = 4, SleepingPattern = 1, SunblockHabit = 2, DietHabit = 5, SkincareProducts = "sunscreen, serum, toner, essence, sheet mask", SunExposure = 4},
        //      new UserSupplementalAcneProfile{IDUserSupplementalAcneProfile = 105, IDUser = 5, SleepingPattern = 2, SunblockHabit = 4, DietHabit = 3, SkincareProducts = "sunscreen, serum, toner, essence, sheet mask", SunExposure = 2},
        //      new UserSupplementalAcneProfile{IDUserSupplementalAcneProfile = 106, IDUser = 6, SleepingPattern = 3, SunblockHabit = 5, DietHabit = 2, SkincareProducts = "sunscreen, serum, toner, essence, sheet mask", SunExposure = 1},


        //  };

        //    context.UserSupplementalAcneProfiles.AddRange(usersupplementalacneprofiles);
        //    context.SaveChanges();


        //    var userdermrequests = new UserDermRequest[]
        //    {
        //        new UserDermRequest{IDUserDermRequest = 200, IDUser = 1, IDUserSupplementalAcneProfile = 101, Comments = "abc"},
        //        new UserDermRequest{IDUserDermRequest = 201, IDUser = 2, IDUserSupplementalAcneProfile = 102, Comments = "abc"},
        //        new UserDermRequest{IDUserDermRequest = 202, IDUser = 3, IDUserSupplementalAcneProfile = 103, Comments = "abc"},
        //        new UserDermRequest{IDUserDermRequest = 203, IDUser = 4, IDUserSupplementalAcneProfile = 104, Comments = "abc"},
        //        new UserDermRequest{IDUserDermRequest = 204, IDUser = 5, IDUserSupplementalAcneProfile = 105, Comments = "abc"},
        //        new UserDermRequest{IDUserDermRequest = 205, IDUser = 6, IDUserSupplementalAcneProfile = 106, Comments = "abc"}
        //    };

        //    context.UserDermRequests.AddRange(userdermrequests);
        //    context.SaveChanges();

        //    var userdermrequestresponses = new UserDermRequestResponse[]
        //    {
        //        new UserDermRequestResponse{IDUserDermRequestResponse = 501, IDDerm = 604, IDUserDermRequest = 200, DermComment = "good", DermPrescription = "tretinoin", DermSuggestion = "stan olivia"},
        //        new UserDermRequestResponse{IDUserDermRequestResponse = 502, IDDerm = 603, IDUserDermRequest = 201, DermComment = "good", DermPrescription = "tretinoin", DermSuggestion = "stan olivia"},
        //        new UserDermRequestResponse{IDUserDermRequestResponse = 503, IDDerm = 603, IDUserDermRequest = 202, DermComment = "good", DermPrescription = "tretinoin", DermSuggestion = "stan olivia"},
        //        new UserDermRequestResponse{IDUserDermRequestResponse = 504, IDDerm = 601, IDUserDermRequest = 203, DermComment = "good", DermPrescription = "tretinoin", DermSuggestion = "stan olivia"},
        //        new UserDermRequestResponse{IDUserDermRequestResponse = 505, IDDerm = 604, IDUserDermRequest = 204, DermComment = "good", DermPrescription = "tretinoin", DermSuggestion = "stan olivia"},
        //        new UserDermRequestResponse{IDUserDermRequestResponse = 506, IDDerm = 603, IDUserDermRequest = 205, DermComment = "good", DermPrescription = "tretinoin", DermSuggestion = "stan olivia" }

        //    };

        //    context.UserDermRequestResponses.AddRange(userdermrequestresponses);
        //    context.SaveChanges();

        //    var userassessments = new UserAssessment[]
        //    {
        //        new UserAssessment{IDUserAssessment = 301, IDUser = 1, DateCreated = DateTime.Parse("5/29/2015"), Score = 4, Ingredients = "glycolic acid"},
        //        new UserAssessment{IDUserAssessment = 302, IDUser = 2, DateCreated = DateTime.Parse("5/30/2015"), Score = 4, Ingredients = "glycolic acid"},
        //        new UserAssessment{IDUserAssessment = 303, IDUser = 3, DateCreated = DateTime.Parse("5/31/2015"), Score = 4, Ingredients = "glycolic acid"},
        //        new UserAssessment{IDUserAssessment = 304, IDUser = 4, DateCreated = DateTime.Parse("6/1/2015"), Score = 4, Ingredients = "glycolic acid"},
        //        new UserAssessment{IDUserAssessment = 305, IDUser = 5, DateCreated = DateTime.Parse("6/2/2015"), Score = 4, Ingredients = "glycolic acid"},
        //        new UserAssessment{IDUserAssessment = 306, IDUser = 6, DateCreated = DateTime.Parse("6/3/2015"), Score = 4, Ingredients = "glycolic acid"}
        //    };

        //    context.UserAssessments.AddRange(userassessments);
        //    context.SaveChanges();

        //    var userassessmenthistories = new UserAssessmentHistory[]
        //   {

        //       new UserAssessmentHistory{IDUserAssessmentHistory = 401, IDUserAssessment = 301},
        //       new UserAssessmentHistory{IDUserAssessmentHistory = 402, IDUserAssessment = 302},
        //       new UserAssessmentHistory{IDUserAssessmentHistory = 403, IDUserAssessment = 303},
        //       new UserAssessmentHistory{IDUserAssessmentHistory = 404, IDUserAssessment = 304},
        //       new UserAssessmentHistory{IDUserAssessmentHistory = 405, IDUserAssessment = 305},
        //       new UserAssessmentHistory{IDUserAssessmentHistory = 406, IDUserAssessment = 306}

        //   };

        //    context.UserAssessmentHistories.AddRange(userassessmenthistories);
        //    context.SaveChanges();


        //    var derms = new Derm[]
        //  {
        //      new Derm{IDDerm = 601},
        //      new Derm{IDDerm = 602},
        //      new Derm{IDDerm = 603},
        //      new Derm{IDDerm = 604},
        //      new Derm{IDDerm = 605},
        //      new Derm{IDDerm = 606},
        //      new Derm{IDDerm = 607}

        //  };

        //    context.Derms.AddRange(derms);
        //    context.SaveChanges();

        //    var dermprofiles = new DermProfile[]
        //  {
        //      new DermProfile{IDDermProfile = 701, IDDerm = 601, DermName = "Taylor Swift", DermEmail = "tay@mail.com", DermPassword = "abc123", DermDateCreated = DateTime.Parse("5/29/2015")},
        //      new DermProfile{IDDermProfile = 702, IDDerm = 602, DermName = "Ariana Grande", DermEmail = "ari@mail.com", DermPassword = "abc123", DermDateCreated = DateTime.Parse("5/30/2015")},
        //      new DermProfile{IDDermProfile = 703, IDDerm = 603, DermName = "Juliette Armanette", DermEmail = "jul@mail.com", DermPassword = "abc123", DermDateCreated = DateTime.Parse("5/31/2015")},
        //      new DermProfile{IDDermProfile = 704, IDDerm = 604, DermName = "Carla Bruni", DermEmail = "car@mail.com", DermPassword = "abc123", DermDateCreated = DateTime.Parse("6/1/2015")},
        //      new DermProfile{IDDermProfile = 705, IDDerm = 605, DermName = "Barbara Pravi", DermEmail = "bar@mail.com", DermPassword = "abc123", DermDateCreated = DateTime.Parse("6/2/2015")},
        //      new DermProfile{IDDermProfile = 706, IDDerm = 606, DermName = "Clara Luciani", DermEmail = "cla@mail.com", DermPassword = "abc123", DermDateCreated = DateTime.Parse("6/3/2015")},
        //      new DermProfile{IDDermProfile = 707, IDDerm = 607, DermName = "Julian Granel", DermEmail = "jul@mail.com", DermPassword = "abc123", DermDateCreated = DateTime.Parse("6/4/2015")}


        //  };

        //    context.DermProfiles.AddRange(dermprofiles);
        //    context.SaveChanges();

        //    var dermpatienthistories = new DermPatientHistory[]
        //  {
        //      new DermPatientHistory{IDDermPatientHistory = 801, IDUserDermRequestResponse = 501, DateCreated = DateTime.Parse("6/7/2015")},
        //      new DermPatientHistory{IDDermPatientHistory = 802, IDUserDermRequestResponse = 502, DateCreated = DateTime.Parse("6/8/2015")},
        //      new DermPatientHistory{IDDermPatientHistory = 803, IDUserDermRequestResponse = 503, DateCreated = DateTime.Parse("6/9/2015")},
        //      new DermPatientHistory{IDDermPatientHistory = 804, IDUserDermRequestResponse = 504, DateCreated = DateTime.Parse("6/10/2015")},
        //      new DermPatientHistory{IDDermPatientHistory = 805, IDUserDermRequestResponse = 505, DateCreated = DateTime.Parse("6/11/2015")},
        //      new DermPatientHistory{IDDermPatientHistory = 806, IDUserDermRequestResponse = 506, DateCreated = DateTime.Parse("6/12/2015")}


        //  };

        //    context.DermPatientHistories.AddRange(dermpatienthistories);
        //    context.SaveChanges();








        //}

    }
}
