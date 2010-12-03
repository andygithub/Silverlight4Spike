I had been recently playing with a framework for WPF/Silverlight.  Hereis an example of some simple screens using the framework and the latest Silverlight toolkit.  I used the 1.1 last official release,  the micro version sounded like it was for the windows phone and the trunk version had some significant drift from the last release and I wanted to get up to speed with something that had some documentation and examples.  The two LOB examples on the site are decent and the one example is where much of the code originated from.  I had also setup some “unit” tests with the toolkit unit testing project framework.

Areas of Interest in the code:

Dependency injection is used throughout.  (Including auto-registration with the Singleton and PerRequest attributes)  This is determined by naming convention of the views, presenters and interfaces. 

Custom property validators (see Model.Interogators)  Notice how extension methods are used to improve the syntax and make validators contextual. 
Public Shared ReadOnly AddressLine1Property As IPropertyDefinition(Of String) = [Property](Of CustomerAddress, String)(Function(x) x.AddressLine1).MustNotBeBlank(My.Resources.Messages.BlankAddressLine1)
Public Property AddressLine1() As String
            Get
                Return GetValue(AddressLine1Property)
            End Get
            Set(ByVal value As String)
                SetValue(AddressLine1Property, value)
            End Set
        End Property

The use of IResult nicely handles all async calls through WCF - WebServiceResult

Using the DataAnnotations and some toolkit controls can really cut down on the text in the xaml file.  Of course I don’t like how it throws an exception on business validation and merging validation errors from service calls would probably be a hassle but the reduction in xaml text is nice.

The unit testing with Silverlight is possible but the frameworks and toolkits are restricted/replace from the desktop toolsets.
