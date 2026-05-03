import {client} from "@/shared/api";
import type {PhoneCreateDto} from "@/pages/CreatePhonePage/model/types.ts";
import type {PhoneDto} from "@/pages/PhonesPage/model/types.ts";

export async function createPhone(data: PhoneCreateDto): Promise<PhoneDto> {
    try {
        const response = await client.post('/Phone/create', data);
        return response.data;
    } catch (error) {
        console.error('Error creating user:', error);
        throw error;
    }
}