using Practice.DesignPattern.FluentBuilder;

// First sample: Simple Builder
var firstSample = FirstSampleBuilder
    .Empty()
    .WithFirstValue(1)
    .WithSecondValue(2)
    .WithThirdValue(3)
    .Build();
Console.WriteLine("--- First sample ---");
Console.WriteLine("Type of object:", firstSample.GetType().FullName);

// Second sample: Complex Builder with Nested object
var secondSample = SecondSampleBuilder
    .Empty()
    .WithFirstValue(1)
    .WithSecondValue(2)
    .WithSecondSample_FirstChild(firstChildBuilder => firstChildBuilder
        .WithKey("First_Key")
        .WithValue("First_Value"))
    .WithSecondSample_SecondChild(secondChildBuilder => secondChildBuilder
        .WithKey("Second_Key")
        .WithValue("Second_Value"))
    .Build();
Console.WriteLine("--- Second sample ---");
Console.WriteLine("Type of object:", secondSample.GetType().FullName);


// Note:
// + Increase complexity of code, hard to write and maintain
// + Instead of directly create new Object, it's always creating new ObjectBuilder and new Object from that new ObjectBuilder
//   With complex builder, when having multiple ObjectBuilder inside,
//   each time call Empty(), create new ObjectBuilder,
//   then each time call Build(), create new Object
//   finally, call Build() to build main object, create new main Object