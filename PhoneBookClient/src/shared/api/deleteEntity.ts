import {client} from '@/shared/api';

export async function deleteEntity(entity: string, id: number) {
    try {
        const response = await client.delete(`/${entity}/delete/${id}`);
        console.log('Deleted successfully:', response.data);
        return response.data;
    } catch (error) {
        console.error('Error deleting:', error);
        throw error;
    }
}