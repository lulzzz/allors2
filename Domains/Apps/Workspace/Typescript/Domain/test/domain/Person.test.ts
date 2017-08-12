import { Person, Session, workspace } from "../../src/allors/domain";

import { assert } from "chai";

describe("Person",
    () => {
        let session: Session;

        beforeEach(() => {
            session = new Session(workspace);
        });

        describe("displayName",
            () => {
                let person: Person;

                beforeEach(() => {
                    person = session.create("Person") as Person;
                });

                it("should be N/A when nothing set", () => {
                    assert.equal(person.displayName, "N/A");
                });

                it("should be john@doe.com when username is john@doe.com", () => {
                    person.UserName = "john@doe.com";
                    assert.equal(person.displayName, "john@doe.com");
                });

                it("should be Doe when lastName is Doe", () => {
                    person.LastName = "Doe";
                    assert.equal(person.displayName, "Doe");
                });

                it("should be John with firstName John", () => {
                    person.FirstName = "John";
                    assert.equal(person.displayName, "John");
                });

                it("should be John Doe (even twice) with firstName John and lastName Doe", () => {
                    person.FirstName = "John";
                    person.LastName = "Doe";
                    assert.equal(person.displayName, "John Doe");
                    assert.equal(person.displayName, "John Doe");
                });
            },
        );
});