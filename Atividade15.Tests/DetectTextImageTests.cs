using Amazon.Rekognition.Model;
using NSubstitute;

namespace Atividade15.Tests;

public class DetectTextImageTests
{
    [Fact]
    public async Task DetectTextLabelAsync_ComParametroValido_RetornaColecaoDeTextos()
    {
        // Arrange
        var sourceImage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "img-example-for-aws-task.jpg");
        var textCollection = new List<TextDetection>
        {
            new TextDetection
            {
                DetectedText = "AWS",
                Type = "LINE",
                Id = 0,
                Confidence = 99.99f,
                Geometry = new Geometry
                {
                    BoundingBox = new BoundingBox
                    {
                        Width = 0.5f,
                        Height = 0.1f,
                        Left = 0.1f,
                        Top = 0.1f
                    }
                }
            }
        };
        var detectTextResponse = new DetectTextResponse
        {
            TextDetections = textCollection
        };
        var rekognitionClientMock = Substitute.For<IRekognitionClientWrapper>();
        rekognitionClientMock.DetectTextAsync(Arg.Any<DetectTextRequest>()).Returns(detectTextResponse);
        var detectTextImage = new DetectTextImage(sourceImage, rekognitionClientMock);
        var resultFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "result.txt");

        // Act
        await detectTextImage.DetectTextLabelAsync(resultFilePath);

        // Assert
        Assert.True(File.Exists(resultFilePath));
        var resultText = await File.ReadAllTextAsync(resultFilePath);
        Assert.Contains("Detected: AWS", resultText);
        Assert.Contains("Confidence: 99,99", resultText);
        Assert.Contains("Id: 0", resultText);
        Assert.Contains("ParentId: ", resultText);
        Assert.Contains("Type: LINE", resultText);
    }
}
