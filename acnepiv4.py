from flask import Flask, request, jsonify
import torch
import torchvision.transforms as transforms
from PIL import Image
from mynet import MyNet  # Import your custom MyNet model

treatment_database = [
    # Treatments for Mild Acne (Level 0)
    {"treatment": "Snail Mucin Extract", "severity": "Mild Acne"},
    {"treatment": "Caffeine", "severity": "Mild Acne"},
    {"treatment": "Propolis", "severity": "Mild Acne"},
    {"treatment": "Bamboo Extract", "severity": "Mild Acne"},
    {"treatment": "Birch Juice", "severity": "Mild Acne"},
    {"treatment": "Ginseng", "severity": "Mild Acne"},
    {"treatment": "Yuza (Yuzu)", "severity": "Mild Acne"},
    {"treatment": "White Truffle Extract", "severity": "Mild Acne"},

    # Treatments for Moderate Acne (Level 1)
    {"treatment": "Salicylic Acid", "severity": "Moderate Acne"},
    {"treatment": "Glycolic Acid", "severity": "Moderate Acne"},
    {"treatment": "Tea Tree Oil", "severity": "Moderate Acne"},
    {"treatment": "Hyaluronic Acid", "severity": "Moderate Acne"},
    {"treatment": "Green Tea Extract", "severity": "Moderate Acne"},
    {"treatment": "Aloe Vera Gel", "severity": "Moderate Acne"},
    {"treatment": "Adapalene", "severity": "Moderate Acne"},
    {"treatment": "Centella Asiatica", "severity": "Moderate Acne"},
    {"treatment": "Activated Charcoal", "severity": "Moderate Acne"},
    {"treatment": "Ceramide", "severity": "Moderate Acne"},

    # Treatments for Advanced Moderate Acne (Level 2)
    {"treatment": "Benzoyl Peroxide", "severity": "Advanced Moderate Acne"},
    {"treatment": "Topical Retinoids (e.g., Tretinoin)", "severity": "Advanced Moderate Acne"},
    {"treatment": "Niacinamide (Vitamin B3)", "severity": "Advanced Moderate Acne"},
    {"treatment": "Sulfur-based Products", "severity": "Advanced Moderate Acne"},
    {"treatment": "Alpha Hydroxy Acids (AHAs)", "severity": "Advanced Moderate Acne"},
    {"treatment": "Zinc Supplements", "severity": "Advanced Moderate Acne"},

    # Treatments for Severe Acne (Level 3)
    {"treatment": "Oral Antibiotics (e.g., Doxycycline)", "severity": "Severe Acne"},
    {"treatment": "Isotretinoin (Accutane)", "severity": "Severe Acne"},
    {"treatment": "Corticosteroid Injections", "severity": "Severe Acne"},
    {"treatment": "Blue Light Therapy", "severity": "Severe Acne"},
    {"treatment": "Microdermabrasion (by a dermatologist)", "severity": "Severe Acne"},
    {"treatment": "Chemical Peels (by a dermatologist)", "severity": "Severe Acne"},
]

# Categorize treatments by severity level
severity_treatments = {}
for entry in treatment_database:
    severity = entry["severity"]
    treatment = entry["treatment"]
    if severity not in severity_treatments:
        severity_treatments[severity] = []
    severity_treatments[severity].append(treatment)

app = Flask(__name__)

# Load your MyNet model from the saved 'best.pt' checkpoint
model = torch.load('best.pt', map_location=torch.device('cpu'))  # Load the model on CPU

# Define the image preprocessing transformation
transform = transforms.Compose([
    transforms.Resize((224, 224)),
    transforms.ToTensor(),
    transforms.Normalize((0.5, 0.5, 0.5), (0.5, 0.5, 0.5))
])

@app.route('/predict', methods=['POST'])
def predict():
    try:
        data = request.get_json()
        image_path = data.get('image_path', None)

        # Load and preprocess the input image based on the provided path
        input_image = Image.open(image_path)
        input_tensor = transform(input_image).unsqueeze(0)

        # Make a prediction using the model
        with torch.no_grad():
            output = model(input_tensor)

        # Assuming it's a classification model, find the class with the highest probability
        predicted_class = torch.argmax(output, dim=1).item()

       # Map the predicted class to severity and treatments
        if predicted_class == 0:
            severity_level = "None"
            suggested_treatments = severity_treatments["Mild Acne"]
        elif predicted_class == 1:
            severity_level = "Mild Acne"
            suggested_treatments = severity_treatments["Moderate Acne"]
        elif predicted_class == 2:
            severity_level = "Moderate Acne"
            suggested_treatments = severity_treatments["Advanced Moderate Acne"]
        elif predicted_class == 3:
            severity_level = "Severe Acne"
            suggested_treatments = severity_treatments["Severe Acne"]
        else:
            severity_level = "Unknown Severity"
            suggested_treatments = []

        # Return the predicted class, severity level, and suggested treatments as JSON response
        response = {
            'acne-score': predicted_class,
            'acne-severity-name': severity_level,
            'ingredients': suggested_treatments
        }
        return jsonify(response)
    except Exception as e:
        return jsonify({'error': str(e)})


if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)


