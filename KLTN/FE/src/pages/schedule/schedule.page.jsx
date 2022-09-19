import ScheduleComponent from "../../components/schedule/schedule.component";

function SchedulePage() {
    const data = {
        1_2: [
          {
            day: "Monday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
          {
            day: "Tuesday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
          {},
          {
            day: "Thursday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
          {},
          {
            day: "Saturday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
        ],
        2_3: [
          {
            day: "Monday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
          {
            day: "Tuesday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
          {},
          {
          },
          {},
          {
            day: "Saturday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
        ],
        3_4: [
          {
          },
          {
            day: "Tuesday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
          {},
          {
            day: "Thursday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
          {},
          {
            day: "Saturday",
            room: "A5-102",
            subject: "Math",
            period: "1-2",
            time: "7-7:45",
            teacher: "Luyen Ngoc Thanh",
          },
        ]
      };
    return ( <div>
        <ScheduleComponent data={data}></ScheduleComponent>
    </div> );
}

export default SchedulePage;