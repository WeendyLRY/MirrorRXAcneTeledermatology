using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcneTeledermatology.Data;
using AcneTeledermatology.Models;
using System.Diagnostics;
using System.IO.Compression;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Tensorflow;
using Microsoft.AspNetCore.Http;

using NumSharp;
using Tensorflow.Keras;
using Newtonsoft.Json;
using System.Text;

namespace AcneTeledermatology.Pages.UserAssessments
{
    public class EditModel : PageModel
    {
        private readonly AcneTeledermatology.Data.AcneTeleContext _context;

        public EditModel(AcneTeledermatology.Data.AcneTeleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAssessment UserAssessment { get; set; } = default!;

        [BindProperty]
        public FileUploadModel ImageUpload { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserAssessments == null)
            {
                return NotFound();
            }

            var userassessment =  await _context.UserAssessments.FirstOrDefaultAsync(m => m.IDUserAssessment == id);
            if (userassessment == null)
            {
                return NotFound();
            }
            UserAssessment = userassessment;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        //public async task<iactionresult> onpostasync()
        //{
        //    if (!modelstate.isvalid)
        //    {
        //        return page();
        //    }

        //    _context.attach(userassessment).state = entitystate.modified;

        //    try
        //    {
        //        await _context.savechangesasync();
        //    }
        //    catch (dbupdateconcurrencyexception)
        //    {
        //        if (!userassessmentexists(userassessment.iduserassessment))
        //        {
        //            return notfound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }


        //    return redirecttopage("./index");
        //}

        //edit this
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //        foreach (var error in errors)
        //        {
        //           // Log or print the validation error messages for debugging

        //           Debug.WriteLine(error.ErrorMessage);
        //            }
        //        return Page();
        //    }

        //    // Handle the file upload

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await ImageUpload.FormFile.CopyToAsync(memoryStream);

        //        // Upload the file if less than 2 MB
        //        if (memoryStream.Length < 2097152)
        //        {
        //            var file = new UserAssessment()
        //            {
        //                image_to_test_path = memoryStream.ToArray()
        //            };

        //            _dbContext.File.Add(file);

        //            await _dbContext.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("File", "The file is too large.");
        //        }
        //    }



        //}


        //if (Request.Form.Files.Count > 0)
        //{
        //    var uploadedFile = Request.Form.Files[0]; // Assuming only one file is uploaded

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await uploadedFile.CopyToAsync(memoryStream);
        //        UserAssessment.image_to_test_path = memoryStream.ToArray();
        //    }
        //}



        //    _context.Entry(UserAssessment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserAssessmentExists(UserAssessment.IDUserAssessment))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");

        //}

        public async Task<IActionResult> OnPostUploadImageAsync()
        {

                if (!ModelState.IsValid)
            {


                // Log or print the validation error messages for debugging

                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    // Log or print the validation error messages for debugging

                    Debug.WriteLine(error.ErrorMessage);
                }
                return Page();

            }

            // Handle the file upload

            var path = "C:\\Users\\weend\\source\\repos\\AcneTeledermatology\\AcneTeledermatology\\wwwroot\\uploads\\img\\";


            if (ImageUpload.FormFile != null && ImageUpload.FormFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await ImageUpload.FormFile.CopyToAsync(memoryStream);

                    // Upload the file if it meets your size criteria...
                    if (memoryStream.Length <= 2097152) // 2 MB limit
                    {
                        // Fetch the existing UserAssessment by its ID
                        var existingUserAssessment = await _context.UserAssessments.FindAsync(UserAssessment.IDUserAssessment);

                        if (existingUserAssessment != null)
                        {
                            // Define a unique file name based on IDUserAssessment and current timestamp
                            var fileName = $"{UserAssessment.IDUserAssessment}_{DateTime.Now.Ticks}.jpg";

                            // Combine the path and file name to get the full image path
                            var imagePath = Path.Combine(path, fileName);

                            // Save the image to the specified path
                            using (var fileStream = new FileStream(imagePath, FileMode.Create))
                            {
                                await ImageUpload.FormFile.CopyToAsync(fileStream);
                            }

                            

                            // Set the existing UserAssessment's ImageToTestPath property to the saved image path
                            existingUserAssessment.ImageToTestPath = imagePath;

                            // Call the API and pass the image path into the API

                            // Define the API endpoint
                            var apiUrl = "http://127.0.0.1:5000/predict"; // Replace with your actual API endpoint

                            // Create a JSON payload with the image path
                            var payload = new { image_path = imagePath };

                            // Send a POST request to the API
                            using (var httpClient = new HttpClient())
                            {
                                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
                                var response = await httpClient.PostAsync(apiUrl, content);

                                if (response.IsSuccessStatusCode)
                                {
                                    var apiResponse = await response.Content.ReadAsStringAsync();
                                    var apiData = JsonConvert.DeserializeObject<ApiResponse>(apiResponse);

                                    // Map the API response fields to UserAssessment properties
                                    existingUserAssessment.Ingredients = string.Join(", ", apiData.Ingredients);
                                    existingUserAssessment.Score_In_text = apiData.AcneSeverityName;
                                    existingUserAssessment.Score = apiData.AcneScore;


                                    // Update the existing UserAssessment
                                    _context.UserAssessments.Update(existingUserAssessment);
                                    await _context.SaveChangesAsync();
                                    return RedirectToPage("./Details", new { id = existingUserAssessment.IDUserAssessment });
                                }
                                else
                                {
                                    // Handle API error
                                    ModelState.AddModelError("ImageUpload.FormFile", "API request failed.");
                                }
                            }


                            // Update the existing UserAssessment
                            _context.UserAssessments.Update(existingUserAssessment);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            return NotFound(); // UserAssessment not found
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("ImageUpload.FormFile", "The image is too large.");
                    }
                }
            }


            return RedirectToPage("./Index");

        }


    

//private object PredictAcneSeverity(object memoryStream)
//    {
//            try
//            {

//                // Load the keras model
//                var model = Tensorflow.Keras.Models.Sequential.LoadModel("acne_detection.h5");


//                // Load the TensorFlow model
//                var modelPath = "acne_detection.h5"; // Replace with the path to your .h5 model file
//                var graph = new TFGraph();
//                var session = new TFSession(graph);
//                graph.Import(File.ReadAllBytes(modelPath));

//                // Convert the memoryStream to a byte array
//                byte[] imageBytes = ((MemoryStream)memoryStream).ToArray();

//                // Prepare the input tensor (assuming you have a placeholder named 'input' in your model)
//                var input = graph["input"][0];

//                // Convert the input data to a NumPy array
//                var inputArray = np.array(imageBytes);

//                // Run the model to get the prediction
//                var runner = session.GetRunner();
//                runner.AddInput(input, inputArray);
//                runner.Fetch("output"); // Replace 'output' with the appropriate output node name

//                var output = runner.Run()[0];

//                // Convert the TensorFlow output tensor to a C# array
//                var prediction = output.GetValue() as float[,];

//                // Map the TensorFlow prediction to the desired output
//                int mappedAcneScore = MapTensorFlowPredictionToAcneScore(prediction);

//                return mappedAcneScore;
//            }
//            catch (Exception ex)
//            {
//                // Handle any exceptions that may occur during the prediction process
//                Console.WriteLine($"An error occurred during acne severity prediction: {ex.Message}");
//                return null; // You may want to handle this more gracefully in your application
//                }
//            }


    private int MapTensorFlowPredictionToAcneScore(dynamic prediction)
        {
            double x = prediction[0];
            double y = prediction[1];
            double z = prediction[2];

            if (x > y && x > z)
            {
                return 1; // Mild to none
            }
            else if (y > x && y > z)
            {
                return 2; // Moderate
            }
            else
            {
                return 3; // Worst
            }
        }


        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // Handle model state errors if needed
        //        return Page();
        //    }

        //    // Your other logic for updating UserAssessment properties

        //    // Call the file upload handler
        //    return await OnPostUploadAsync();
        //}

        //public async Task<IActionResult> OnPostUploadAsync()
        //{
        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await ImageUpload.FormFile.CopyToAsync(memoryStream);
        //        //  Upload the file if it meets your size criteria
        //        if (memoryStream.Length <= 2097152) // 2 MB limit
        //        {
        //            // Fetch the existing UserAssessment by its ID
        //            var existingUserAssessment = await _context.UserAssessments.FindAsync(UserAssessment.IDUserAssessment);


        //            if (existingUserAssessment != null)
        //            {
        //                // Set the existing UserAssessment's image_to_test_path property to memoryStream.ToArray()
        //                existingUserAssessment.image_to_test_path = memoryStream.ToArray();

        //                // Manually set Ingredients to its existing value
        //                // This avoids validation errors since you're not modifying it
        //                existingUserAssessment.Ingredients = existingUserAssessment.Ingredients;


        //                // Update the existing UserAssessment
        //                _context.UserAssessments.Update(existingUserAssessment);
        //                await _context.SaveChangesAsync();
        //            }
        //            else
        //            {
        //                return NotFound(); // UserAssessment not found
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("ImageUpload.FormFile", "The image is too large.");
        //        }

        //        return RedirectToPage("./Index");
        //    }
        //}

        
        



        private bool UserAssessmentExists(int id)
        {
          return (_context.UserAssessments?.Any(e => e.IDUserAssessment == id)).GetValueOrDefault();
        }





    }


}
