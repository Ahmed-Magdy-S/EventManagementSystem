import { EventModel } from "../models/EventModel";
import axios from "axios";

axios.defaults.baseURL = "http://localhost:5039/api/events";


export async function getAllEvents(): Promise<EventModel[]> {
    const response = await axios.get<EventModel[]>("/");
    return response.data;
}

export async function getEventDetails(id: string): Promise<EventModel> {
    const response = await axios.get<EventModel>(`/${id}`);
    return response.data;
}

export async function deleteEvent(id: string): Promise<void> {
     await axios.delete(`/${id}`);
}

export async function createEvent(Event: EventModel): Promise<void> {
    
}

export async function updateEvent(Event: EventModel): Promise<void> {

}