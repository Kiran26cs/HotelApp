export class RoomDetail {
  roomType: string
  roomNo: string
}

export class RoomType {
  roomTypeId: string
  roomTypeValue: string
}

export class RoomDetailServiceResponse {
  roomType: string
  roomNo: string
  status: string
}

export class RoomDetailServiceResponseWrapper {
  roomsData: RoomDetailServiceResponse[]
}
