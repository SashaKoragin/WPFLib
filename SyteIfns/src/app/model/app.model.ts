export class Face {
    SqlFaceErrorResult: SqlFaceErrorResult;
}

class SqlFaceErrorResult {
    faceErrorField: FaceErrorField[];
}

export class FaceErrorField {
    fN212Field: FN212Field;
    idField: number;
    idFieldSpecified: boolean;
    messageeField: string;
    n1newField: number;
    n1newFieldSpecified: boolean;
    n1oldField: number;
    n1oldFieldSpecified: boolean;
}

class FN212Field {
    d3Field: string;
    fID_EntityField: string;
    n134Field: string;
    n18Field: string;
    n1Field: number;
    n1FieldSpecified: boolean;
}

export class FaceAdd {
    N1Old:number;
    N1New:number;
}