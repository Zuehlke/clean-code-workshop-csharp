using NUnit.Framework;

namespace AdditionalExercises.IntToEnum;

[TestFixture]
public class SystemStateTest
{
    [Test]
    public void testGetStateAllServicesOk()
    {
        var state = new SystemState(SystemState.ALL_SERVICES_OK);
        Assert.That(state.getState(), Is.EqualTo(SystemState.ALL_SERVICES_OK));
    }

    [Test]
    public void testGetStateCommunicationOk()
    {
        var state = new SystemState(SystemState.COMMUNICATION_OK);
        Assert.That(state.getState(), Is.EqualTo(SystemState.COMMUNICATION_OK));
    }

    [Test]
    public void testGetStateReportServiceFailure()
    {
        var state = new SystemState(SystemState.REPORT_SERVICE_FAILURE);
        Assert.That(state.getState(), Is.EqualTo(SystemState.REPORT_SERVICE_FAILURE));
    }

    [Test]
    public void testGetDescriptionForStateAllServicesOk()
    {
        Assert.That(SystemState.getDescriptionForState(SystemState.ALL_SERVICES_OK), Is.EqualTo("All Services OK"));
    }

    [Test]
    public void testGetDescriptionForStateCommunicationOk()
    {
        Assert.That(SystemState.getDescriptionForState(SystemState.COMMUNICATION_OK), Is.EqualTo("Communication OK"));
    }

    [Test]
    public void testGetDescriptionForStateReportServiceFailure()
    {
        Assert.That(SystemState.getDescriptionForState(SystemState.REPORT_SERVICE_FAILURE),
            Is.EqualTo("ReportService Failure"));
    }

    [Test]
    public void testGetDescriptionForUnknownState()
    {
        Assert.That(SystemState.getDescriptionForState(42), Is.EqualTo("Unknown state"));
        Assert.That(SystemState.getDescriptionForState(-42), Is.EqualTo("Unknown state"));
    }

    [Test]
    public void testGetDescriptionForCornerCases()
    {
        Assert.That(SystemState.getDescriptionForState(7), Is.EqualTo("Unknown state"));
        Assert.That(SystemState.getDescriptionForState(-1), Is.EqualTo("Unknown state"));
    }
}