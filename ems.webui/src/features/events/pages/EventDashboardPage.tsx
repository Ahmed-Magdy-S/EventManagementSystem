import { Col, Container } from "react-bootstrap";
import { EventList } from "../components/EventList";

export function EventDashboardPage() {




    return (
        <Container fluid className="bg-light p-4">
            <Col md={7}>
                <EventList />
            </Col>
        </Container>

    );
}