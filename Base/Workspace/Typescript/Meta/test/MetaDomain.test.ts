import * as chai from "chai";
import * as meta from "../src/meta";
import * as data from "../src/meta/base/Data";

const expect = chai.expect;

describe("MetaDomain",
    () => {
        describe("default constructor",
        () => {

            let metaPopulation = new meta.Population();

            it("should be newable",
                () => {
                    expect(metaPopulation).not.null;
                });

            describe("init with empty data population", () => {

                metaPopulation.init();

                it("should contain 8 types",
                    () => {
                        expect(Object.keys(metaPopulation.objectTypeByName).length).equal(8);
                    });

                it("should contain Binary, Boolean, DateTime, Decimal, Float, Integer, String, Unique",
                    () => {
                        ["Binary", "Boolean", "DateTime", "Decimal", "Float", "Integer", "String", "Unique"].forEach(name => {
                            let unit = metaPopulation.objectTypeByName[name];
                            expect(unit).not.null;
                        });
                    });
            });
        });
});
