import { AssociationType } from "./AssociationType";
import { ConcreteMethodType } from "./ConcreteMethodType";
import { ConcreteRoleType } from "./ConcreteRoleType";
import { Class, Data, Interface } from "./Data";
import { ExclusiveMethodType } from "./ExclusiveMethodType";
import { ExclusiveRoleType } from "./ExclusiveRoleType";
import { MetaObject } from "./MetaObject";
import { MethodType } from "./MethodType";
import { Kind, ObjectType } from "./ObjectType";
import { RoleType } from "./RoleType";

export class Population {
  public readonly domains: string[] = [];

  public readonly objectTypeByName: { [name: string]: ObjectType; } = {};

  public readonly metaObjectById: { [id: string]: MetaObject; } = {};

  public createMetaDomain(): any {
    const metaDomain = {};
    Object.keys(this.objectTypeByName)
      .forEach((objectTypeName) => {
        const objectType = this.objectTypeByName[objectTypeName];
        const metaObjectType = {
          ObjectType: objectType,
        };
        metaDomain[objectTypeName] = metaObjectType;

        Object.keys(objectType.roleTypeByName)
          .forEach((roleTypeName) => {
            const roleType = objectType.roleTypeByName[roleTypeName];
            metaObjectType[roleTypeName] = roleType;
          });

        objectType.associationTypes.forEach((associationType) => {
          metaObjectType[associationType.name] = associationType;
        });
      });

    return metaDomain;
  }

  public baseInit(this: Population, data: Data) {

    // Domains
    data.domains.forEach((dataDomain) => {
      if (this.domains.indexOf(dataDomain) > 1) {
        this.domains.push(dataDomain);
      }
    });

    const idByTypeName = {
      Binary: "c28e515bcae84d6b95bf062aec8042fc",
      Boolean: "b5ee6cea4E2b498ea5dd24671d896477",
      DateTime: "c4c0934361d3418cade2fe6fd588f128",
      Decimal: "da866d8e2c4041a8ae5b5f6dae0b89c8",
      Float: "ffcabd07f35f4083bef6f6c47970ca5d",
      Integer: "ccd6f13426de4103bff9a37ec3e997a3",
      String: "ad7f5ddcbedb4aaa97acd6693a009ba9",
      Unique: "6dc0a1a888a44614adb492dd3d017c0e",
    };

    // Units
    ["Binary", "Boolean", "DateTime", "Decimal", "Float", "Integer", "String", "Unique"]
      .forEach((name) => {
        const metaUnit = new ObjectType();
        metaUnit.id = idByTypeName[name];
        metaUnit.name = name;
        metaUnit.kind = Kind.unit;
        this.objectTypeByName[metaUnit.name] = metaUnit;
        this.metaObjectById[metaUnit.id] = metaUnit;
      });

    // Interfaces
    data.interfaces.forEach((dataInterface) => {
      const metaInterface = new ObjectType();
      metaInterface.id = dataInterface.id;
      metaInterface.name = dataInterface.name;
      metaInterface.kind = Kind.interface;
      this.objectTypeByName[metaInterface.name] = metaInterface;
      this.metaObjectById[metaInterface.id] = metaInterface;
    });

    // Classes
    data.classes.forEach((dataClass) => {
      const metaClass = new ObjectType();
      metaClass.id = dataClass.id;
      metaClass.name = dataClass.name;
      metaClass.kind = Kind.class;
      this.objectTypeByName[metaClass.name] = metaClass;
      this.metaObjectById[metaClass.id] = metaClass;
    });

    const dataObjectTypes = [].concat(data.interfaces).concat(data.classes);

    dataObjectTypes.forEach((dataObjectType: Interface | Class) => {
      const metaObjectType = this.objectTypeByName[dataObjectType.name];

      dataObjectType.interfaces.forEach((dataInterface) => {
        const metaInterface = this.objectTypeByName[dataInterface];
        metaObjectType.interfaceByName[metaInterface.name] = metaInterface;
      });

      if (dataObjectType.exclusiveRoleTypes) {
        dataObjectType.exclusiveRoleTypes.forEach((dataRoleType) => {
          const objectType = this.objectTypeByName[dataRoleType.objectType];
          const metaRoleType = new ExclusiveRoleType();
          metaRoleType.id = dataRoleType.id;
          metaRoleType.name = dataRoleType.name;
          metaRoleType.objectType = objectType;
          metaRoleType.isOne = dataRoleType.isOne;
          metaRoleType.isRequired = dataRoleType.isRequired;
          metaObjectType.exclusiveRoleTypes.push(metaRoleType);
          this.metaObjectById[metaRoleType.id] = metaRoleType;
        });
      }

      if (dataObjectType.associationTypes) {
        dataObjectType.associationTypes.forEach((dataAssociationType) => {
          const metaAssociationType = new AssociationType();
          metaAssociationType.id = dataAssociationType.id;
          metaAssociationType.name = dataAssociationType.name;
          metaObjectType.associationTypes.push(metaAssociationType);
          this.metaObjectById[metaAssociationType.id] = metaAssociationType;
        });
      }

      if (dataObjectType.exclusiveMethodTypes) {
        dataObjectType.exclusiveMethodTypes.forEach((dataMethodType) => {
          const metaMethodType: ExclusiveMethodType = new ExclusiveMethodType();
          metaMethodType.id = dataMethodType.id;
          metaMethodType.name = dataMethodType.name;
          metaObjectType.exclusiveMethodTypes.push(metaMethodType);
          this.metaObjectById[metaMethodType.id] = metaMethodType;
        });
      }
    });

    data.interfaces.forEach((dataInterface) => {
      const metaInterface = this.objectTypeByName[dataInterface.name];
    });

    data.classes.forEach((dataClass) => {
      const metaObjectType = this.objectTypeByName[dataClass.name];

      if (dataClass.concreteRoleTypes) {
        dataClass.concreteRoleTypes.forEach((dataRoleType) => {
          const metaRoleType: RoleType = this.metaObjectById[dataRoleType.id] as RoleType;
          const metaConcreteRoleType: ConcreteRoleType = new ConcreteRoleType();
          metaConcreteRoleType.roleType = metaRoleType;
          metaConcreteRoleType.isRequired = dataRoleType.isRequired;
          metaObjectType.concreteRoleTypes.push(metaConcreteRoleType);
        });
      }

      if (dataClass.concreteMethodTypes) {
        dataClass.concreteMethodTypes.forEach((dataMethodType) => {
          const metaMethodType: MethodType = this.metaObjectById[dataMethodType.id] as MethodType;
          const metaConcreteMethodType: ConcreteMethodType = new ConcreteMethodType();
          metaConcreteMethodType.methodType = metaMethodType;
          metaObjectType.concreteMethodTypes.push(metaConcreteMethodType);
        });
      }
    });

    Object.keys(this.objectTypeByName)
      .map((name) => this.objectTypeByName[name])
      .forEach((objectType) => objectType.derive());
  }
}