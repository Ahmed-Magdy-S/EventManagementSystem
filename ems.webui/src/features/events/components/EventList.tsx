import { useEffect, useState } from "react";
import { CardGroup } from "react-bootstrap";
import { EventModel } from "../../../App/models/EventModel";
import { EventListItem } from "./EventListItem";
import { getAllEvents } from "../../../App/api/EventsAPI"



export function EventList() {

    const [events, setEvents] = useState<EventModel[]>([]);

    useEffect(() => {
        getAllEvents().then(events => {
            setEvents(events);
        })
    }, []);



    const eventListItems = events.map((event: EventModel) =>
        <EventListItem key={event.id} eventItem={event} />
    )


    return (
        <CardGroup className="flex-column gap-3" >
            {eventListItems}
        </CardGroup>
    )

}