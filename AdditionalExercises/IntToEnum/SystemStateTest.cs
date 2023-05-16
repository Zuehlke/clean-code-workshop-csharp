using NUnit.Framework;

namespace AdditionalExercises.IntToEnum;

[TestFixture]
public class SystemStateTest
{
    [Test]
    public void TestGetStateAllServicesOk()
    {
        var state = new SystemState(SystemState.AllServicesOk);
        Assert.That(state.State, Is.EqualTo(SystemState.AllServicesOk));
    }

    [Test]
    public void TestGetStateCommunicationOk()
    {
        var state = new SystemState(SystemState.CommunicationOk);
        Assert.That(state.State, Is.EqualTo(SystemState.CommunicationOk));
    }

    [Test]
    public void TestGetStateReportServiceFailure()
    {
        var state = new SystemState(SystemState.ReportServiceFailure);
        Assert.That(state.State, Is.EqualTo(SystemState.ReportServiceFailure));
    }

    [Test]
    public void TestGetDescriptionForStateAllServicesOk()
    {
        Assert.That(SystemState.GetDescriptionForState(SystemState.AllServicesOk), Is.EqualTo("All Services OK"));
    }

    [Test]
    public void TestGetDescriptionForStateCommunicationOk()
    {
        Assert.That(SystemState.GetDescriptionForState(SystemState.CommunicationOk), Is.EqualTo("Communication OK"));
    }

    [Test]
    public void TestGetDescriptionForStateReportServiceFailure()
    {
        Assert.That(
            SystemState.GetDescriptionForState(SystemState.ReportServiceFailure),
            Is.EqualTo("ReportService Failure"));
    }

    [Test]
    public void TestGetDescriptionForUnknownState()
    {
        Assert.That(SystemState.GetDescriptionForState(42), Is.EqualTo("Unknown state"));
        Assert.That(SystemState.GetDescriptionForState(-42), Is.EqualTo("Unknown state"));
    }

    [Test]
    public void TestGetDescriptionForCornerCases()
    {
        Assert.That(SystemState.GetDescriptionForState(7), Is.EqualTo("Unknown state"));
        Assert.That(SystemState.GetDescriptionForState(-1), Is.EqualTo("Unknown state"));
    }
}