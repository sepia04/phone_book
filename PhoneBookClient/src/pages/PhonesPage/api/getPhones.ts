import {client} from '@/shared/api';
import type {PhoneDto} from "../model/types.ts";

export function getPhones() {
    return client.get<PhoneDto[]>("/Phone/phones");
}