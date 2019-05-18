//code from https://medium.freecodecamp.org/reducing-css-bundle-size-70-by-cutting-the-class-names-and-using-scope-isolation-625440de600b
const incstr = require("incstr");

const createUniqueIdGenerator = () => {
    const index = {};

    const generateNextId = incstr.idGenerator({
        // Removed "d" letter to avoid accidental "ad" construct.
        // @see https://medium.com/@mbrevda/just-make-sure-ad-isnt-being-used-as-a-class-name-prefix-or-you-might-suffer-the-wrath-of-the-558d65502793
        alphabet: "abcefghijklmnopqrstuvwxyz"
    });

    return name => {
        if (index[name]) {
            return index[name];
        }

        let nextId;

        do {
            // Class name cannot start with a number.
            nextId = generateNextId();
        } while (/^[0-9]/.test(nextId));

        index[name] = generateNextId();

        return index[name];
    };
};

const uniqueIdGenerator = createUniqueIdGenerator();

module.exports = (componentName, localName) =>
    uniqueIdGenerator(componentName) + "_" + uniqueIdGenerator(localName);
