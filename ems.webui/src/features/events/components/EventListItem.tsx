import { Button, Card } from "react-bootstrap";
import { EventModel } from "../../../App/models/EventModel";

interface Prop {
    eventItem: EventModel;
}

export function EventListItem({ eventItem }: Prop) {

    return (
        <Card className="p-3">
            <Card.Title>{eventItem.title}</Card.Title>
            <Card.Subtitle>{eventItem.date.toString()}</Card.Subtitle>
            <Card.Text>{eventItem.description}</Card.Text>
            <Card.Text>{eventItem.city}, {eventItem.place}</Card.Text>
            <Button className="d-inline-block">View</Button>
        </Card>
    );
}