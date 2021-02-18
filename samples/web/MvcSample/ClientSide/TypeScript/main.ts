import { DayOfWeek } from "./Enums/enumDateValues";

export function Main() {
    var theDate = new Date();
    var todaysDay = theDate.getDay();

    console.log(DayOfWeek[todaysDay].toString());

    console.log(getTodaysGreeting(todaysDay));
   
}

const getTodaysGreeting = (todaysDay: number) => {
    if (todaysDay === DayOfWeek.Saturday || todaysDay === DayOfWeek.Sunday) {
        return "Yeah! It's the weekend!";
    } else {
        return "It's a weekday. Get back to work";
    }
}
