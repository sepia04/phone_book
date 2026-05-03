import {client} from "@/shared/api";
import type {PhoneDto} from "@/pages/PhonesPage/model/types.ts";
import type {PhoneUpdateDto} from "@/pages/UpdatePhonePage/model/types.ts";

export async function updatePhone(
    data: PhoneUpdateDto
): Promise<PhoneDto> {
    try {
        const response = await client.put(`/Phone/update/`, data);
        return response.data;
    } catch (error) {
        console.error('Error updating phone:', error);
        throw error;
    }
}